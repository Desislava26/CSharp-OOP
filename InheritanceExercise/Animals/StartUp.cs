using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command;
            string type;
            List<Animal> animals = new List<Animal>();

            while ((command = Console.ReadLine()) != "Beast!")
            {
                type = command;
                command = Console.ReadLine();
                string [] arr = command.Split(' ');
                string name = arr[0];
                int age = int.Parse(arr[1]);
                string gender = arr[2];
                Animal animal = null;
                if (type == "Cat")
                {
                    Cat cat = new Cat(name,age,gender);
                    animal = cat;
                }
                else if(type == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    animal = dog;
                }
                else if (type == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    animal = frog;
                }
                else if (type == "Kitten")
                {
                    Kitten kit = new Kitten(name, age);
                    animal = kit;
                }
                else if (type == "Tomcat")
                {
                    Tomcat tomkit = new Tomcat(name, age);
                    animal=tomkit;
                }
                else
                {
                    throw new Exception("Invalid input");
                }
                animals.Add(animal);
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
            
        }
    }
}
