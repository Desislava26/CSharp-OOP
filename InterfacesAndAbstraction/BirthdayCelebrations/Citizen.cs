
namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    using System.Text;
    public class Citizen : IIdentity
    {
        private string name;
        private int age;
        private string egn;
        //public string Egn { get; private set; }
        public DateTime Birthday { get; private set; }

        public string Name { get; private set; }

        public Citizen(string name, int age, string eng, DateTime dating)
        {
            Name = name;
            this.age = age;
            this.egn = eng;
            Birthday = dating;
        }
    }
}
