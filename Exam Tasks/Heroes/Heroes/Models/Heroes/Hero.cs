using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero:IHero
    {
        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
            }
        }

        private int health;

        public int Health
        {
            get { return health; }
            set 
            {
                if (value >= 0)
                {

                    health = value;
                }
                else
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
            }
        }
        private int armour;

        public int Armour
        {
            get { return armour; }
            set
            {
                if (value >= 0)
                {

                    armour = value;
                }
                else
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
            }
        }

        private bool isAlive;

        public bool IsAlive
        {
            get { return isAlive; }
            set 
            {
                if(health > 0)
                {
                    value = true;
                }
                else
                {
                    value = false;
                }
                isAlive = value; 
            }
        }
        
        private IWeapon weapon;
        public IWeapon Weapon //=> throw new NotImplementedException();
        {
            get { return weapon; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Weapon cannot be null.");
                }
                
                weapon = value;
            }
        }




        public void TakeDamage(int points)
        {
            int leftoverPoints = 0;

            armour -= points;
            if (armour <= 0)
            {
                leftoverPoints = Math.Abs(Armour);
                armour = 0;
            }

            if (leftoverPoints > 0)
            {
                health -= leftoverPoints;

                if (health < 0)
                {
                    health = 0;
                }
            }


        }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
          
        }
    }
}
