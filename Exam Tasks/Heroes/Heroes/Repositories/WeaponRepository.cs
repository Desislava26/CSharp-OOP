using Heroes.Models.Contracts;
using Heroes.Models.Weapons;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    internal class WeaponRepository : IRepository<IWeapon>
    {
        private readonly Dictionary<string, IWeapon> weapons;
        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.weapons.Values;

       

        public void Add(IWeapon model)
        {
            this.weapons.Add(model.Name, model);
        }

        public IWeapon FindByName(string name)
        {

            if (this.weapons.ContainsKey(name))
            {
                return this.weapons[name];
            }
            return null;
        }

        public bool Remove(IWeapon model)
        {
            foreach (var item in this.weapons)
            {
                if(item.Value == model)
                {
                    this.weapons.Remove(item.Key);
                    return true;
                }
                

            }
            return false;
        }
    }
}
