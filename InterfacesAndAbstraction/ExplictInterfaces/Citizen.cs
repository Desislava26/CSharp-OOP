using System;
using System.Collections.Generic;
using System.Text;

namespace ExplictInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }
        public int Age { get; private set; }

        
    }
}
