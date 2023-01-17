using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        protected Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Price = price;

        }
        private string name;
        public string Name 
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name cannot be null or empty.");
                }
                name = value;
            }
        }
        private string species;
        public string Species
        {
            get => species;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }
                species = value;
            }
        }

        private int size;
        public int Size
        {
            get => size;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Size");
                }
                size = value;
            }
        }

        private decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }
                price = value;
            }
        }

        public abstract void Eat();
        
    }
}
