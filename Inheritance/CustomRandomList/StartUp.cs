using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main()
        {
            RandomList listing = new RandomList();
            listing.Add("one");
            listing.Add("two");
            listing.Add("three");
            Console.WriteLine(listing.RandomString());
            
        }
    }
}
