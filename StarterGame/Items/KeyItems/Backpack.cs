﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StarterGame
{
    public class Backpack : I_Item
    {

        private float weight;

        public float Weight { get { return weight; } }

        private readonly string name = "Backpack";

        public string Name { get { return name; } }

        private readonly string description; 
           
        public string Description { get { return description; }}

        private int purchasePrice; 
        public int PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; } }
        private int sellPrice;
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.KeyItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        private int capacity;
        public int Capacity { get { return capacity; } }



        private Dictionary<string, List<I_Item>> inventory;
        public Dictionary<string, List<I_Item>> Inventory { get { return inventory; } }


        public Backpack()
        {
            weight = 0; //Weight should be 0
            uses = 1; //Doesn't matter
            purchasePrice = 999999999;
            sellPrice = 999999999;
            capacity = 30;
            description = "Pretty useful for holding items. \n\tCapacity: " + Capacity + "lbs";
            itemTypes = new HashSet<ItemType>(types);
            inventory = new Dictionary<string, List<I_Item>>(); 
        }

        /**
         * Item is added to the backpacks inventory of individual items. 
         * @params: (I_Item) item to be added to inventory
         * @returns: void
         **/
        public void giveItem(I_Item item)
        {
            List<I_Item> check = null;
            Inventory.TryGetValue(item.Name, out check); 
            if(check == null)
            {
                Inventory[item.Name] = new List<I_Item>();
                Inventory[item.Name].Add(item); 
            }
            else
            {
                Inventory[item.Name].Add(item); 
            }
        }

        /**
         * Takes an item from the backpacks inventory of that individual item. The first item in the list of that specific item 
         * is removed. 
         * @params: (string) The name of the item to be removed. 
         * @returns: (I_Item) The item that was removed. 
         **/
        public I_Item takeItem(string item)
        {
            List<I_Item> check = null;
            Inventory.TryGetValue(item, out check);
            if (check != null && check.Count != 0)
            {
                I_Item temp = check.First();
                Inventory[item].Remove(temp);
                if (Inventory[item].Count == 0)
                {
                    Inventory.Remove(item);
                }
                return temp;
            }
            else
            {
                Console.WriteLine("Item does not exist in your backpack!");
                return null;
            }
        }

        /**
         * Takes an item from the backpacks inventory of that specific item. The name and position of that specific item are given. 
         * @params: (string)The name of the item to remove, (position) The chosen item by the player to remove 
         * @returns: (I_Item) The item that was to be removed. 
         **/
        public I_Item takeItem(string item, int position)
        {
            List<I_Item> check = null;
            Inventory.TryGetValue(item, out check); 
            if(check != null && check.Count != 0)
            {
                I_Item temp = check[position-1];
                Inventory[item].RemoveAt(position-1);
                if(Inventory[item].Count <= 0)
                {
                    Inventory.Remove(item); 
                }
                return temp; 
            }
            else
            {
                Console.WriteLine("Item does not exist in your backpack!");
                return null; 
            }

        }

        /**
         * The total weight of items in the bag. 
         * @params: none
         * @returns: (float) The total weight of all items in the backpack. 
         **/
        public float weightInBag()
        {
            float temp = 0;
            Dictionary<string, List<I_Item>>.ValueCollection values = Inventory.Values;
            foreach(List<I_Item> items in values)
            {
                foreach(I_Item item in items)
                {
                    temp += item.Weight;
                }
            }
            return temp; 
        }

        /**
         * Indicates whether there is sufficient space to add an item to the backpack. 
         * @params: (I_Item) The item that we are checking space in backpack for. 
         * @returns: (bool) Whether the item checked will fit in the backpack without going over capacity. 
         **/
        public bool spaceInBag(I_Item item)
        {
            if (this.Weight + item.Weight > capacity)
            {
                Console.WriteLine("You don't have room in your backpack");
                return false;
            }
            return true;  
        }

        /**
         * Displays all of the items currently in the backpack and how many there are. 
         * @params: none
         * @returns: (string) neatly formatted string of all items in the backpack and how many. 
         **/
        public string displayItems()
        {
            string list = "";
            Dictionary<string, List<I_Item>>.ValueCollection values = Inventory.Values;
            list += "\nWeight in Bag: " + weightInBag() + "lbs\n\t";
            foreach (List<I_Item> item in values)
            {
                list += item.First().Name + ": " + item.Count + "\n\t";
            }
            return list;
        }


        /**This displays every single weapon and it's stats at current time. 
         * @params: none
         * @returns: (string) instance of all weapons in position. 
         **/
        public string displayWeapons()
        {
            string list = "";
            Dictionary<string, List<I_Item>>.ValueCollection values = Inventory.Values;
            list += "Weapons: \n\t";
            foreach (List<I_Item> item in values)
            {
                if (item.First().ItemTypes.Contains(ItemType.Weapon))
                {
                    foreach(IWeapon weapon in item)
                    {
                        list += weapon.ToString(); 
                    }
                }
            }
            return list;
        }

        /**
         * Displays every instance of one type of weapon in inventory
         * @params: (string) name of weapon
         * @returns: (string) each instance of weapon of this kind in inventory (i.e all Axes if player has multiples)
         **/
        public string displayWeapons(string name)
        {
            string list = "";
            List<I_Item> values = null;
            Inventory.TryGetValue(name, out values);
            int count = 1;
            list += "Weapons: \n"; 
            foreach(IWeapon weapon in values)
            {
                list += count + ") " + weapon.ToString();
                count++;
            }
            return list; 
        }

        /**
         * Given an item name, checks to see if that item is currently in the backpack
         * @params: (string) The name of the item to look for. 
         * @returns: (bool) True/False value whether that item is in the backpack. 
         **/
        public bool itemInBag(string item)
        {
            List<I_Item> check = null;
            Inventory.TryGetValue(item, out check);
            return check != null; 
        }

        /**
         * Provides a copy of an item in the bag to check certain properties. 
         * @params: (string) The name of the item to check
         * @returns: (I_Item) Copy of the item to be checked. 
         **/
        public I_Item checkItem(string item)
        {
            return Inventory[item].First<I_Item>(); 
        }

        /**
         * Lets the player know they cannot use the backpack with a command 
         * @params: (Player) 
         * @returns: void
         **/
        public void useItem(Player player)
        {
            Console.WriteLine("Can't really do all that.");
        }
    }
}
