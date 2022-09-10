using System;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;

            while((command = Console.ReadLine())!= "End")
            {
                string[] arg = command.Split(' ');
                string type = arg[0];
                Animal animal = null;
                
                //if(type == "Owl")
                //{
                //    animal = new Owl(arg[1], double.Parse(arg[2]), int.Parse(arg[3]));
                //}
                //else if (type == "Hen")
                //{

                //}
                //else if (type == "Mouse")
                //{

                //}
                //else if (type == "Dog")
                //{

                //}
                //else if (type == "Cat")
                //{
                //    animal = new Cat(arg[1], double.Parse(arg[2]), int.Parse(arg[3]), arg[4], arg[5]);
                //}
                //else if (type == "Tiger")
                //{
                //    animal = new Tiger(arg[1], double.Parse(arg[2]), int.Parse(arg[3]), arg[4], arg[5]);
                //}
            }
        }
    }
}
