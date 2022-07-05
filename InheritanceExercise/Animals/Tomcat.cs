using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string KittenGender = "Male";
        public Tomcat(string name, int age) : base(name, age, KittenGender)
        {
        }
        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
