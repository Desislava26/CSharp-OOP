using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double consumPlus = 1.6;
        private const double modify = 0.95;

        public Truck(double fuelQuantity, double fuelConsumpPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumpPerKm + consumPlus, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                double totalFuel = base.FuelQuantity + liters * 0.95;
                if (totalFuel > base.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    base.FuelQuantity += liters * 0.95;
                }
            }
            //FuelQuantity += (liters * modify);
        }

        //public override void Refuel(double liters)
        //{
        //    this.FuelConsumpPerKm *= modify;
        //    base.Refuel(liters);
        //    //FuelQuantity *= modify;
        //}
    }
}
