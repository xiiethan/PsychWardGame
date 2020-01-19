﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface IWeapon : I_Item
    {
        int Attack { get; set; }
        int RepairCost { get; }
        int MaxUse { get; set; }
        int getStrength(Player player);
        new void useItem(Player player);
        void useWeaponDescription(Player player);
        void useWeapon(Player player);

    }
}
