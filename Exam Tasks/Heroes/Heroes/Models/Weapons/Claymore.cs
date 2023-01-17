using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    internal class Claymore : Weapon
    {
        public Claymore(string name, int durability) : base(name, durability)
        {
            //Damage = damage;
        }
       // public int Damage { get; set; } = 20;
        public override int DoDamage()
        {

            if (Durability > 0)
            {
                this.Durability--;

                return 20;
            }

            return 0;
        }
    }
}
