
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplictInterfaces
{
   public interface IPerson
    {
        string Name { get; }
        int Age { get; }

        string GetName(string name)
        {
            return $"{name}";
        }

    }
}
