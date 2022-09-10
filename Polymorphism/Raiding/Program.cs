using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> listing = new List<BaseHero>();
            string heroName;
            string heroType;
            int sumPowerHero = 0;
            BaseHero hero = null;
            int counter = 0;
            while (counter != n)
            {
                heroName = Console.ReadLine();
                heroType = Console.ReadLine();
                try
                {
                   
                    if (heroType == "Druid")
                    {
                        hero = new Druid(heroName);
                    }
                    else if (heroType == "Paladin")
                    {
                        hero = new Paladin(heroName);
                    }
                    else if (heroType == "Rogue")
                    {
                        hero = new Rogue(heroName);

                    }
                    else if (heroType == "Warrior")
                    {
                        hero = new Warrior(heroName);
                    }
                    else
                    {
                        throw new Exception("Invalid hero!");
                    }
                    sumPowerHero+= hero.Power;
                    listing.Add(hero);
                    counter++;
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            foreach (var r in listing)
            {
                Console.WriteLine(r.CastAbility());
            }

            if (bossPower<= sumPowerHero)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

    
        
    }

}
