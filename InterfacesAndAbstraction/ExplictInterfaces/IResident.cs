using System;
using System.Collections.Generic;
using System.Text;

namespace ExplictInterfaces
{
    public interface IResident: IPerson
    {
       string GetName(string name)
        {
            return $"Mr/Ms/Mrs {name}";
        }
    }
}
