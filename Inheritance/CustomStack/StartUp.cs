using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StartUp
    {
        static void Main()
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.AddRange(new List<string>() { "1", "2", "3" });
            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }
    }
}
