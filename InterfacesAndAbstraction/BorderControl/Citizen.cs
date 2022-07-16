using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentity
    {
        //public string Name { get; private set; }

        //public int Age { get; private set; }
        private string name;
        private int age;
        public string Egn { get; private set; }

        public Citizen(string name, int age, string eng)
        {
            this.name = name;
            this.age = age;
            Egn = eng;
        }
    }
}
