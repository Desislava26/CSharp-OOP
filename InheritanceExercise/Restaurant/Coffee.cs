using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    internal class Coffee : HotBeverage
    {
        private const double Coffmilliliters = 50;
        private const decimal Coffprice = 3.50M;
        public Coffee(string name, double caffeine) : base(name, Coffprice, Coffmilliliters)
        {
            Caffeine = caffeine;
        }

      
        public double Caffeine { get; set; }

    }
}
