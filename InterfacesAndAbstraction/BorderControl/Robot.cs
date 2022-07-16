using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IIdentity
    {
        private string name;
        public string Egn { get; private set; }

        public Robot(string name, string egn)
        {
            this.name = name;
            Egn = egn;
        }
    }
}
