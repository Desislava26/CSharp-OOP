using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon:IWeapon
    {
        private int damage;
       
        protected Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }

        private string name;

        public string Name
        {
            get { return name; }
             set 
            {
                if (value != null || value != "")
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
            }
        }

        private int durability;

        public int Durability
        {
            get { return durability; }
            set
            {
                if (value >=0)
                {
                    durability = value;
                }
                else
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
            }
        }

        public abstract int DoDamage();
        
       

    }
}
