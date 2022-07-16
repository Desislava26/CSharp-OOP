using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;

        public string FlourType
        {
            get { return flourType; }
            private set {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }
                
                flourType = value; 
            }
        }


        private string bakingTech;

        public string BakingTech
        {
            get { return bakingTech; }
            private set { bakingTech = value; }
        }

        private const double white = 1.5;
        private const double wholegrain = 1.0;
        private const double crispy = 0.9;
        private const double chewy = 1.1;
        private const double homemade = 1.0;

        private double calories;

        public double Calories
        {
            get { return calories; }
            private set 
            {
                if (value >= 1 && value <= 200)
                {
                    calories = value;
                }
                else
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
            }
        }
       


        public double Calculation()
        {
            double baking = 0.0;
            double flour = 0.0;
            if(BakingTech.ToLower() == "crispy")
            {
                baking = crispy;
                
            }
            else if(BakingTech.ToLower() == "chewy")
            {
                baking = chewy;
            }
            else if (BakingTech.ToLower() == "homemade")
            {
                baking = homemade;
            }
            if (FlourType.ToLower() == "white")
            {
                flour = white;
            }
            else if (FlourType.ToLower() == "wholegrain")
            {
                flour = wholegrain;
            }

            double res = (2 * calories) * flour * baking;
            return res ;
        }
        public Dough(string flourType, string bakingTech, double calories)
        {
            FlourType = flourType;

            BakingTech = bakingTech;
            Calories = calories;

        }


    }
}
