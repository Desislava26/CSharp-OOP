using System;

namespace ExplictInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            //IPerson citizen = new Citizen("desi", "bg", 19);
            //IResident mr = new Citizen("desito", "bgg", 20);
            //Console.WriteLine(citizen.GetName("desi"));
            //Console.WriteLine(mr.GetName("desito"));

            string command;
            while((command = Console.ReadLine()) != "End")
            {
                string [] arg = command.Split(' ');
                IPerson citizen = new Citizen(arg[0], arg[1], int.Parse(arg[2]));
                IResident residence = new Citizen(arg[0], arg[1], int.Parse(arg[2]));
                Console.WriteLine(citizen.GetName(arg[0]));
                Console.WriteLine(residence.GetName(arg[0]));
            }

        }
    }
}
