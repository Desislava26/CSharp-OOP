using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IByer
    {
        public int Food { get; private set; } = 0;
        public string Name { get; private set; }
        private int age;
        private string egn;
        private DateTime birthday = new DateTime();
        public void BuyFood()
        {
            Food = 10;
        }
       

        public Citizen(string name, int age, string egn, DateTime birthday)
        {
            Name = name;
            this.age = age;
            this.egn = egn;
            this.birthday = birthday;
        }
    }
}
