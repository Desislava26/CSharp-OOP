
namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    using System.Text;
    public class Robot : IIdentity
    {
        //private string name;
        private string egn;
        public string Name { get; private set; }

        public Robot(string name, string egn)
        {
            Name = name;
            this.egn = egn;
        }
    }
}
