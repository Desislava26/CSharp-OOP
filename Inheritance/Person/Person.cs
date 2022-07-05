using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}, Age: {this.Age}");
            return sb.ToString();
        }


    }
}
