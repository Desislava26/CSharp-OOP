﻿using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
      
        public BioChemicalWeapon(int destructionLevel) : base( destructionLevel, 3.2)
        {
        }



  
    }
}