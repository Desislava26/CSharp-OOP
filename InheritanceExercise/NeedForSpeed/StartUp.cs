using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            //double kilometers = double.Parse(Console.ReadLine());
            //int horsePower = int.Parse(Console.ReadLine());
            //double fuel = double.Parse(Console.ReadLine());
            Vehicle vench = new Vehicle(100,100);
            //SportCar car = new SportCar(fuel, horsePower);

             vench.Drive(9);
            Console.WriteLine(vench.Fuel);
        }
    }
}
