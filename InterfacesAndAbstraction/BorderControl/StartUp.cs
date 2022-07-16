using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BorderControl
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            List<IIdentity> listing = new List<IIdentity>();
            while((command = Console.ReadLine()) != "End")
            {
                string [] input =command.Split(' ');
                if(input.Length == 3)
                {
                    IIdentity person = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    listing.Add(person);
                }
                else if(input.Length == 2)
                {
                    IIdentity robot = new Robot(input[0], input[1]);
                    listing.Add(robot);
                }
            }
            string final = Console.ReadLine();
            
            listing.Where(c => c.Egn.EndsWith(final))
           .Select(c => c.Egn)
           .ToList()
           .ForEach(Console.WriteLine);

            
        }
    }
}
