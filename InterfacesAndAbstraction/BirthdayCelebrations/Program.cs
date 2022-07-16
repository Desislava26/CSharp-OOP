
namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            List<DateTime> listing = new List<DateTime>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(' ');
                if (input[0].ToLower() == "citizen")
                {
                    DateTime dating = DateTime.ParseExact(input[4], "dd/MM/yyyy", null);

                    IIdentity person = new Citizen(input[1], int.Parse(input[2]), input[3], dating);
                    listing.Add(dating);
                    
                }
                else if (input[0].ToLower() == "robot")
                {
                    IIdentity robot = new Robot(input[1], input[2]);

                }
                else if (input[0].ToLower() == "pet")
                {
                    DateTime dating = DateTime.ParseExact(input[2], "dd/MM/yyyy", null);
                    IIdentity pet = new Pet(input[1], dating);
                    listing.Add(dating);
                }
            }
            int  final = int.Parse(Console.ReadLine());

            listing.Where(x => x.Year == final)
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString(@"dd\/MM\/yyyy")));
        }
    }
}
