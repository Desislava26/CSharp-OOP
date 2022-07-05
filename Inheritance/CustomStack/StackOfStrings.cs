using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    internal class StackOfStrings: Stack<string>
    {
        public bool IsEmpty()
        {
            if(this.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Stack<string> AddRange(IEnumerable<string> elements)
        {
            foreach (var item in elements)
            {
                this.Push(item);
            }
            return this;
        }
    }
}
