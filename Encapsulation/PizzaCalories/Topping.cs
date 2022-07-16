using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double meat = 1.2;
        private const double veggies = 0.8;
        private const double cheese = 1.1;
        private const double sauce = 0.9;

        private string type;

        public string Type
        {
            get { return type; }
            private set 
            {
                if(value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                type = value; 
            }
        }
        private double calories;
        public double Calories
        {
            get { return calories; }
            private set
            {
                if (value >= 1 && value <= 50)
                {
                    calories = value;
                }
                else
                {
                    throw new Exception($"{Type} weight should be in the range [1..50].");
                }
            }
        }
        public Topping(string type, double calories)
        {
            Type = type;
            Calories = calories;
        }
        public double Calculation()
        {
            double baking = 0.0;
            
            if (Type.ToLower() == "meat")
            {
                baking = meat;

            }
            else if (Type.ToLower() == "veggies")
            {
                baking = veggies;
            }
            else if (Type.ToLower() == "cheese")
            {
                baking = cheese;
            }
            else if (Type.ToLower() == "sauce")
            {
                baking = sauce;
            }
            

            double res = calories * baking;
            return res;
        }


    }
}
