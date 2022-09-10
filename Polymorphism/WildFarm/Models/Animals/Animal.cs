using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal:ICreatingAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            //FoodEaten = foodEaten;
        }

        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public abstract string ProducingSound();

        public void CreatingAnimal(string [] arg, string type)
        {
            Animal animal = null;
            if (type == "Owl")
            {
                animal = new Owl(arg[1], double.Parse(arg[2]), int.Parse(arg[3]));
            }
            else if (type == "Hen")
            {

            }
            else if (type == "Mouse")
            {

            }
            else if (type == "Dog")
            {

            }
            else if (type == "Cat")
            {
               // animal = new Cat(arg[1], double.Parse(arg[2]), int.Parse(arg[3]), arg[4], arg[5]);
            }
            else if (type == "Tiger")
            {
                //animal = new Tiger(arg[1], double.Parse(arg[2]), int.Parse(arg[3]), arg[4], arg[5]);
            }
        }

        

        public readonly ICollection<Type> types = new HashSet<Type>();
        public double GainedWeight { get; protected set; }
    }
}
