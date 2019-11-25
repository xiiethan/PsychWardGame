﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Bat : I_Item, IWeapon
    {
        //SEE I_iTEM INTERFACE FOR EXPLAINATION OF ALL PROPERTIES!!
        private readonly string name = "bat";
        public string Name { get { return name; } }
        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BattleItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string description = "A real slap in the face to whoever you swing on";
        public string Description { get { return description + "\nAttack: " + Attack; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }
        private int attack;
        public int Attack { get { return attack; } set { attack = value; } }

        public Bat()
        {
            attack = 10;
            weight = 1.8f;
            itemTypes = new HashSet<ItemType>(types);
            uses = 50; 
            value = 500;
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
