using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public int Battery { get; set ; }
        public string Model { get; set; }
        public string Color { get ; set; }
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;

        }

        public string Start()
        {
            return "Engine Start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }
    }
}
