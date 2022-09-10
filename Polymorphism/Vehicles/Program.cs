using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
          
            string [] argCar = Console.ReadLine().Split(' ');
            string[] argTruck = Console.ReadLine().Split(' ');
            string[] argBus = Console.ReadLine().Split(' ');

            Vehicle car = new Car(double.Parse(argCar[1]), double.Parse(argCar[2]), double.Parse(argCar[3]));
            Vehicle truck = new Truck(double.Parse(argTruck[1]), double.Parse(argTruck[2]), double.Parse(argTruck[3]));
            Vehicle bus = new Bus(double.Parse(argBus[1]), double.Parse(argBus[2]), double.Parse(argBus[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                if(command[0] == "Drive")
                {
                    if(command[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(command[2])));
                    }
                    else if (command[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(command[2])));
                    }
                    else if(command[1] == "Bus")
                    {
                        Console.WriteLine(bus.Drive(double.Parse(command[2])));
                    }
                }
                else if (command[0] == "Refuel")
                {
                    if (command[1] == "Car")
                    {
                        car.Refuel(double.Parse(command[2]));
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(command[2]));
                    }
                    else if (command[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(command[2]));
                    }

                }
                else if (command[0] == "DriveEmpty")
                {
                    bus.FuelConsumpPerKm -= 1.4;
                    Console.WriteLine(bus.Drive(double.Parse(command[2])));
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");

        }
    }
}
