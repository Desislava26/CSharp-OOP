using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           
                string[] numbers = Console.ReadLine().Split(' ');
                string[] websites = Console.ReadLine().Split(' ');
                foreach (var item in numbers)
                {
                    if (item.Length == 7)
                    {
                        ICallable ph = new StationaryPhone();
                        Console.WriteLine(ph.Calling(item));
                    }
                    else if (item.Length == 10)
                    {
                        IBrowseble cal = new Smartphone();
                        Console.WriteLine(cal.Calling(item));

                    }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
                }
                foreach (var item in websites)
                {
                    IBrowseble cal = new Smartphone();
                    Console.WriteLine(cal.Browsing(item));

                }
            }
            
            
        }
    }

