using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Calling(string number)
        {
            if (IsValid(number))
            {
                return $"Dialing... {number}";
            }
            return "Invalid number!";
        }
       
        private bool IsValid(string number)
        {
            foreach (char ch in number)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
