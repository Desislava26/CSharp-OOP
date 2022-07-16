using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IByer
    {
        public int Food { get; private set; } = 0;
        public string Name { get; private set; }
        private int age;
        private string group;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            this.age = age;
            this.group = group;
        }

        public void BuyFood()
        {
            Food = 5;
        }
    }
}
