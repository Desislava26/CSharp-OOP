using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone: ICallable, IBrowseble
    {
        public string Browsing(string website)
        {
            if (IsValid(website))
            {
                return $"Browsing: {website}!";
            }
            else
            {
                return "Invalid URL!";
            }
        }

        public string Calling(string number)
        {
            if (IsValidNum(number))
            {
                return $"Calling... {number}";
            }
            return "Invalid number!";
            
        }
        private bool IsValidNum(string number)
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
        private bool IsValid(string website)
        {
            foreach (char ch in website)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
