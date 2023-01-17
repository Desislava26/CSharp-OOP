using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = null;
            IWeapon weapon = null;
            if (heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException ($"Hero {heroName} does not exist.");
            }
            else 
            {
                hero = heroes.FindByName(heroName); 
            }
            if (weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            else
            {
                weapon = weapons.FindByName(weaponName);
            }
            if(hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            //IHero hero = null;

            //if (type == "Knight")
            //{
            //    hero = new Knight(name, health, armour);
            //}
            //else if (type == "Barbarian")
            //{
            //    hero = new Barbarian(name, health, armour);
            //}
            //else
            //{
            //    throw new InvalidOperationException("Invalid hero type.");
            //}


            //if (heroes.FindByName(name) != null)
            //{
            //    throw new InvalidOperationException($"The hero {name} already exists.");
            //}

            //heroes.Add(hero);

            //    if(hero.GetType().Name == "Knight")
            //    {
            //        return $"Successfully added Sir { name } to the collection.";
            //    }
            //    else if (hero.GetType().Name == "Barbarian")
            //        {
            //            return $"Successfully added Sir { name } to the collection.";
            //        }
            //else
            //{
            //    throw new InvalidOperationException("Invalid hero type.");
            //}
            IHero hero = null;

            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
            }
            else if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }


            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            heroes.Add(hero);

            return hero.GetType().Name == "Knight"
                ? $"Successfully added Sir {name} to the collection."
                : $"Successfully added Barbarian {name} to the collection.";



        }

        public string CreateWeapon(string type, string name, int durability)
        {

            IWeapon weapon = null;
            if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            var existingWeapon = weapons.Models.FirstOrDefault(w => w.Name == name);

            if (existingWeapon != null)
            {
                throw new InvalidOperationException($"The weapon { name } already exists.");
            }

            weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            var filter = heroes.Models.OrderBy(w => w.GetType().Name)
                .ThenByDescending(w => w.Health)
                .ThenBy(w => w.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var hero in filter)
            {
                string weaponName = string.Empty;
                if (hero.Weapon == null)
                {
                    weaponName = "Unarmed";
                }
                else
                {
                    weaponName = hero.Weapon.Name;
                }
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health }");
                sb.AppendLine($"--Armour: {hero.Armour }");
                sb.AppendLine($"--Weapon: {weaponName }");
            }
            return sb.ToString().Trim();
        }
        public string StartBattle()
        {
            IMap map = null;
            List<IHero> fighters = heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            return map.Fight(fighters);

        }
    }
}
