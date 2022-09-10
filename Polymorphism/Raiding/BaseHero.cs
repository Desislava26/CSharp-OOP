using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
           
        }

        public string Name { get; protected set; }
        public virtual int Power { get; protected set; }

        public virtual string CastAbility() 
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }

        
    }
}
