
namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    using System.Text;
    public class Pet : IIdentity
    {
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }


        public Pet(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
        }
    }
}
