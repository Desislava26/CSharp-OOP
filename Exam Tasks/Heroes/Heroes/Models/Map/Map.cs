using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            //var knights = players
            //    .OfType<Knight>()
            //.Where(x => x.IsAlive)
            //.ToList();

            //var barbarians = players
            //    .OfType<Barbarian>()
            //.Where(x => x.IsAlive)
            //.ToList();
            var listKnights = new List<Knight>();
            var listBarbarian = new List<Barbarian>();

            foreach (var hero in players)
            {
                //var listKnights = new List<Knight>();
                //var listBarbarian = new List<Barbarian>();
                if (hero.IsAlive)
                {
                    if (hero is Knight knight)
                    {
                        listKnights.Add(knight);
                    }
                    else if (hero is Barbarian barbarian)
                    {
                        listBarbarian.Add(barbarian);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid hero type");
                    }
                }
            }
                var continueBattle = true;
                while(continueBattle)
                {
                    var allknightsdead = true;
                    var allbarbariandead = true;

                    int aliveknights = 0;
                    int alivebarbarian = 0;
                    foreach ( var knight in listKnights)
                    {
                        if (knight.IsAlive)
                        {
                            allknightsdead = false;
                            aliveknights++;
                            foreach  (var item in listBarbarian)
                            {
                                var weaponDamage = knight.Weapon.DoDamage();
                                item.TakeDamage(weaponDamage);
                            }
                        }
                    }
                    foreach (var barbarian in listBarbarian)
                    {
                        if (barbarian.IsAlive)
                        {
                            allbarbariandead = false;
                            alivebarbarian++;

                            foreach (var item in listBarbarian)
                            {
                                var weaponDamage = barbarian.Weapon.DoDamage();
                                item.TakeDamage(weaponDamage);
                            }
                        }

                    }
                    if (allknightsdead)
                    {
                    int count = listBarbarian.Count(x => x.IsAlive == false);
                    return $"The barbarians took {count} casualties but won the battle.";
                    }
                    else if (allbarbariandead)
                    {
                    int count = listKnights.Count(x => x.IsAlive == false);
                    return $"The knights took {count} casualties but won the battle.";
                    }
                 
                }
           
            throw new Exception("There is a bug");
        }
    }
}
