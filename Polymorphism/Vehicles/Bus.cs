using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double consumVent = 1.4;
        public Bus(double fuelQuantity, double fuelConsumpPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumpPerKm+= consumVent, tankCapacity)
        {
        }

        public virtual string DriveEmpty(double distance)
        {
            //this.FuelConsumpPerKm += consumVent;
            return this.Drive(distance);
           
        }
       
       
        
    }
}
