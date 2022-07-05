using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Animal animal = new Animal(name);
            Reptile reptile = new Reptile(name);
            Lizard lizard = new Lizard(name);
            Snake snake = new Snake(name);
            Mammal mammal = new Mammal(name); 
            Gorilla gorilla = new Gorilla(name);
            Bear bear = new Bear(name);

        }
    }
}