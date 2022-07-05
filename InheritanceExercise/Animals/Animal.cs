using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        private int age;

        public int Age
        {
            get { return age; }
            set {
                if (value >= 0)
                {
                    age = value;
                }
                else
                {
                    throw new Exception("Invalid input!");
                }
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Invalid input!");
                }
            }
        }
        private string gender;

        public string Gender
        {
            get { return gender; }
            set {
                if (!String.IsNullOrEmpty(value))
                {
                    gender = value;
                }
                else
                {
                    throw new Exception("Invalid input!");
                }
            }
        }



        public abstract string ProduceSound();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(ProduceSound());
            return sb.ToString().TrimEnd();
        }

    }
}
