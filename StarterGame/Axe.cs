﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Axe : I_Item, IWeapon
    {
        private readonly string name = "Axe";
        public string Name { get { return name; }  }
        private Dictionary<string, ItemType> itemTypes;
        public Dictionary<string, ItemType> ItemTypes { get { return itemTypes; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string description = "It hacks and wacks to destroy your enemies";
        public string Description { get { return description + "\nAttack: " + Attack; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }
        private int attack;
        public int Attack { get { return attack; } set { attack = value; } }

        public Axe()
        {
            attack = 11;
            weight = 1.25f;
            itemTypes = new Dictionary<string, ItemType>();
            itemTypes.Add(name, ItemType.BattleItem);
            uses = 1;
            value = 850;
        }

        public int getStrength(Player player)
        {
            return player.Attack + Attack;
        }

        public void useItem(Player player)
        {
            player.outputMessage("Cannot use " + Name + " right now.\n");
        }

        public void useWeapon(Player player)
        {
            Uses--; 
            if (Uses <= 0)
            {
                player.Weapon = null; 
            }
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nAttack: " + attack + "\nWeight: " + weight;
        }

    }
}
