﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;

        public double Height
        {
            get { return height; }
            set 
            { if(value <= 0)
                {
                    throw new Exception();
                }
                height = value; }
        }

        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        
        }

        public double Width
        {
            get { return width; }
            protected set {
                if (value <= 0)
                {
                    throw new Exception();
                }
                width = value; }
        }


        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return (this.Height + this.Width) * 2;
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
