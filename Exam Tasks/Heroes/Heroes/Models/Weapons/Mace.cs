using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        public Mace(string name, int durability) : base(name, durability)
        {
            //Damage = damage;
        }
        //public int Damage { get; set; } = 25;

        public override int DoDamage()
        {
            if (Durability > 0)
            {
                this.Durability--;

                return 25;
            }

            return 0;
        }
    }
}
