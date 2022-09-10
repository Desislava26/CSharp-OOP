using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private readonly ICollection<IDecoration> decor;
        private readonly ICollection<IFish> fishs;
        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decor = new List<IDecoration>();
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

        private int capacity;
        public int Capacity
        {
            get => capacity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Size");
                }
                capacity = value;
            }
        }

        private int comfort;
        public int Comfort
        {
            get => comfort;
            set
            {
                int sum = 0;
                foreach (var item in Decorations)
                {
                    sum += item.Comfort;
                }
                comfort = sum;
                comfort = value;
            }
        }

        public ICollection<IDecoration> Decorations => decor;

        public ICollection<IFish> Fish => fishs;

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if(Fish.Count < this.Capacity)
            {
                this.Fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
        }

        public void Feed()
        {
            foreach (var item in this.Fish)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            var fishNames = fishs.Select(f => f.Name).ToList();
            string fishesAsString = fishs.Count == 0 ? "none" : string.Join(", ", fishNames);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fishesAsString}");
            sb.AppendLine($"Decorations: {decor.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
            // var fishNames = fishs.Select(f => f.Name).ToList();
            // StringBuilder sb = new StringBuilder();
            // sb.AppendLine($"{this.Name} ({ this.GetType().Name}):");
            // if (this.fishs.Count == 0)
            // {
            //     sb.AppendLine($"Fish: none");
            // }
            // else
            // {

            //     sb.AppendLine($"Fish: {string.Join(", ", fishNames)}");
            // }
            //// sb.AppendLine($"Decorations: {this.Decorations.Count}");
            // sb.AppendLine($"Decorations: {this.Decorations.Count}");
            // sb.AppendLine($"Comfort: {this.Comfort}");
            // return sb.ToString();
        }

        public bool RemoveFish(IFish fish)
        {
            foreach (var item in this.Fish)
            {
                if(item == fish)
                {
                    this.Fish.Remove(fish);
                    return true;
                }
            }
            return false;
        }
    }
}
