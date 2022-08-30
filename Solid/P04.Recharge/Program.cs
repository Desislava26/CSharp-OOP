namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            ISleeper human = new Employee("12345");
            human.Sleep();
            IRechargeable robot = new Robot("12345", 50);
            robot.Recharge();
        }
    }
}
