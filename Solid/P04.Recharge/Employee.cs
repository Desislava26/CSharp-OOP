﻿namespace P04.Recharge
{
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            Console.WriteLine("sleep...");
        }

        //public override void Recharge()
        //{
        //    throw new InvalidOperationException("Employees cannot recharge");
        //}

    }
}
