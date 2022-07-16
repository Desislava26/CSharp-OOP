using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    double lenght = double.Parse(Console.ReadLine());
            //    double width = double.Parse(Console.ReadLine());
            //    double height = double.Parse(Console.ReadLine());

            //    Box box = new Box(lenght, width, height);



            //    //Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            //    //Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
            //    //Console.WriteLine($"Volume - {box.Volume():f2}");
            //    Console.WriteLine(box.ToString());
            //}
            //catch (ArgumentException ae)
            //{

            //    Console.WriteLine(ae.Message);
            //}
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = null;
            try
            {
                box = new Box(length, width, height);

            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
                return;
            }
            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.Volume():f2}");



        }
    }
}
