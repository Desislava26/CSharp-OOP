using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class MilitaryUnit : IMilitaryUnit
    {
        private int enduranceLevel = 1;
        private double cost;

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
        }

        public double Cost
        {
            get => cost;
            private set => cost = value;
        }

        public int EnduranceLevel => enduranceLevel;

        public void IncreaseEndurance()
        {
            enduranceLevel++;

            if (enduranceLevel > 20)
            {
                enduranceLevel = 20;
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
            
            
        }
    }
}
