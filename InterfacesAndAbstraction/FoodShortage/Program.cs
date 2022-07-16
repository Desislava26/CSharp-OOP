using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IByer> list = new List<IByer>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                if (command.Length == 4)
                {
                    DateTime dating = DateTime.ParseExact(command[3], "dd/MM/yyyy", null);
                    IByer citizen = new Citizen(command[0], int.Parse(command[1]), command[2], dating);
                    list.Add(citizen);

                }
                else if (command.Length == 3)
                {

                    IByer citizen = new Rebel(command[0], int.Parse(command[1]), command[2]);
                    list.Add(citizen);
                    
                }
            }
            string input;
            int total = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                if (list.Any(x => x.Name == input))
                {
                    var str = list.First(x => x.Name == input);
                    var type = str.GetType().Name;
                    if(type == "Citizen")
                    {
                        str.BuyFood();
                     
                    }
                    else if (type == "Rebel")
                    {
                        str.BuyFood();
                  
                    }
                    total += str.Food;
                }
            }

            Console.WriteLine(total);

        }
    
    
    }
}

