using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) : base(name, CakePrice, CakeGrams, CakeCalories)
        {
        }
       // public override double Grams => 250;
       // public override double Calories => 1000;
        //public override decimal Price => 5;

        private const double CakeGrams = 250;
        private const double CakeCalories = 1000;
        private const decimal CakePrice = 5m;

    }
}
