using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;

        public string Name
        {
            get { return name; }
            private set {
                if(value.Length <1 && value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
        }
        private int countTop;

        public int CountTop
        {
            get { return countTop; }
            private set {
                if (value < 0 && value > 10)
                {
                    throw new Exception("Number of toppings should be in range [0..10]");
                }
                countTop = value; 
            }
        }
        public Pizza(string name, int countTop)
        {
            Name = name;
            CountTop = countTop;
        }

    }
}
