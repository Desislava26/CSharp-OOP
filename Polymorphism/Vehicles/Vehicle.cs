using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumpPerKm, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumpPerKm = fuelConsumpPerKm;
            if (tankCapacity >= fuelQuantity)
            {
                this.FuelQuantity = fuelQuantity;
            }
            else
            {
                this.FuelQuantity = 0;
            }
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get;  set; }
        public double FuelConsumpPerKm { get; set; }

        public double TankCapacity { get; set; }

        public virtual string  Drive(double distance)
        {
            if (distance * FuelConsumpPerKm > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            FuelQuantity -= distance * FuelConsumpPerKm;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (TankCapacity < FuelQuantity+liters)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    FuelQuantity += liters;
                }
            }
        }

        
    }
}
