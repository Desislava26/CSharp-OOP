using PlanetWars.Core.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planetRepo;
       
        public Controller()
        {
            planetRepo = new PlanetRepository();
          
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit unit = null;
         
            var plan = planetRepo.FindByName(planetName);

            if(plan == null)
            {
                throw new InvalidOperationException($"Planet { planetName } does not exist!");
            }
            
            foreach (var item in plan.Army)
            {
                if (item.GetType().Name == unitTypeName)
                {
                    throw new InvalidOperationException($"{ unitTypeName } already added to the Army of { planetName}!");
                }

            }
            
            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            plan.Spend(unit.Cost);
            plan.AddUnit(unit);
            
            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            
            var plan = planetRepo.FindByName(planetName);
            if(plan == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            
            foreach (var item in plan.Weapons)
            {
                if(item.GetType().Name == weaponTypeName)
                {
                    throw new InvalidOperationException($"{ weaponTypeName } already added to the Weapons of { planetName}!");
                }
             
            }
            
            IWeapon unit = null;

            if (weaponTypeName == "BioChemicalWeapon")
            {
                unit = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                unit = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                unit = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }
            plan.Spend(unit.Price);
            plan.AddWeapon(unit);
            return $"{ planetName} purchased { weaponTypeName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planetRepo.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            Planet planet = new Planet(name, budget);
            planetRepo.AddItem(planet);
            return $"Successfully added Planet: {planet.Name}";
        }

        public string ForcesReport()
        {
            var ordered = planetRepo.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in ordered)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var attacker = planetRepo.FindByName(planetOne);
            var defender = planetRepo.FindByName(planetTwo);

            bool attackerIsNuclear = attacker.Weapons.Any(w => w is NuclearWeapon);
            bool defenderIsNuclear = defender.Weapons.Any(w => w is NuclearWeapon);
            IPlanet winner = null;
            IPlanet looser = null;
            if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                winner = attacker;
                looser = defender;
            }
            else if (defender.MilitaryPower > attacker.MilitaryPower)
            {
                winner = defender;
                looser = attacker;
            }
            else
            {
                if (attackerIsNuclear && !defenderIsNuclear)
                {
                    winner = attacker;
                    looser = defender;
                }
                else if (defenderIsNuclear && !attackerIsNuclear)
                {
                    winner = defender;
                    looser = attacker;
                }
                else
                {
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(looser.Budget / 2);
            winner.Profit(looser.Army.Sum(u => u.Cost) + looser.Weapons.Sum(w => w.Price));

            planetRepo.RemoveItem(looser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);

        }

        public string SpecializeForces(string planetName)
        {
            var planet = planetRepo.FindByName(planetName);
            if(planet == null)
            {
                throw new InvalidOperationException($"Planet { planetName } does not exist");
            }
            if(planet.Army.Count == 0)
            {
                throw new InvalidOperationException($"No units available for upgrade!");
            }
            planet.Spend(1.25);
            planet.TrainArmy();
            return $"{planetName} has upgraded its forces!";
        }

        public void Peace()
        {
            return;
        }

        
    }
}
