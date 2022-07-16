using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string command;
                string[] argg = Console.ReadLine().Split();
                string name = argg[1];
                int toppCount = 0;
                double calc = 0;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] arg = command.Split(' ');
              
                   
                    if (arg[0].ToLower() == "dough")
                    {
                        Dough d = new Dough(arg[1], arg[2], double.Parse(arg[3]));
                        calc += d.Calculation();
                        //Console.WriteLine($"{d.Calculation():f2}");
                    }
                    else if (arg[0].ToLower() == "topping")
                    {
                        Topping d = new Topping(arg[1], double.Parse(arg[2]));
                        //Console.WriteLine($"{d.Calculation():f2}");
                        toppCount++;
                        calc += d.Calculation();
                    }
                }
                Pizza pizza = new Pizza(name, toppCount);
                Console.WriteLine($"{pizza.Name} - {calc:f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}
