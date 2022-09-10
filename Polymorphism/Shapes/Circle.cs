using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            protected set
            {
                if (value <= 0)
                {
                    throw new Exception();
                }
                radius = value;
            }
        }
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius; //Math.Round((Radius * Radius) * Math.PI);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius; //Math.Round(2*Math.PI * radius);
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
