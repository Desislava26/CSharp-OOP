using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        //private double lenght;

        //public double Lenght
        //{
        //    get { return lenght; }
        //    private set 
        //    {
        //        if(value <= 0)
        //        {
        //            throw new ArgumentException($"{nameof(Lenght)} cannot be zero or negative.");
        //        }
        //        lenght = value; 
        //    }
        //}

        //private double width;

        //public double Width
        //{
        //    get { return width; }
        //    private set
        //    {
        //        if (value <= 0)
        //        {
        //            throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
        //        }
        //        width = value;
        //    }
        //}

        //private double height;

        //public double Height
        //{
        //    get { return height; }
        //    private set
        //    {
        //        if (value <= 0)
        //        {
        //            throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
        //        }
        //        height = value;
        //    }
        //}

        //public Box(double lenght, double width, double height)
        //{
        //    Lenght = lenght;
        //    Width = width;
        //    Height = height;

        //}

        //public double SurfaceArea()
        //{
        //    return (2*Lenght * Width) + (2* Height*Lenght) + (2*Width*Height);
        //}

        //public double LateralSurfaceArea()
        //{
        //    return (2*Lenght*Height) + (2*Width*Height);
        //}

        //public double Volume()
        //{
        //    return (Width * Height * Lenght);
        //}

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
        //    sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
        //    sb.AppendLine($"Volume - {Volume():f2}");
        //    return sb.ToString().TrimEnd();
        //}

        private const double SIDE_MIN_VALUE = 0;
        private const string INVALID_SIDE_MESSEGE = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Lenght = length;
            this.Width = width;
            this.Height = height;
        }

        private double Lenght
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

       
        private double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

       
        private double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }
        public double SurfaceArea()
        {
            double area = 2 * (this.Lenght * this.Width) +
                2 * (this.Lenght * this.Height) +
                2 * (this.Width * this.Height);
            return area;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = (2 * this.Lenght * this.Height) +
                (2 * this.Width * this.Height);
            return lateralSurfaceArea;
        }
        public double Volume()
        {
            double volume = this.Width * this.Lenght * this.Height;
            return volume;
        }



    }
}
