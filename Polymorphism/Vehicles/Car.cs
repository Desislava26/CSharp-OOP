
using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double consumPlus = 0.9;
        public Car(double fuelQuantity, double fuelConsumpPerKm,double tankCapacity) : base(fuelQuantity, fuelConsumpPerKm + consumPlus,tankCapacity )
        {
        }
    }
}
