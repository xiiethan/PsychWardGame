﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class InfectedDoctor :IEnemy
    {
        private readonly string name = "Infected Doctor";
        public override string Name { get { return name; } }

        private int attack;
        public override int Attack { get { return attack; } set { attack = value; } }
        private int health;
        public override int Health { get { return health; } set { health = value; } }

        private int hitProbability;
        public override int HitProbability { get { return hitProbability; } }

        private int playerExp;
        public override int PlayerExp { get { return playerExp; } set { playerExp = value; } }
        private I_Item drops = new SutureKit();
        public override I_Item getDrops()
        {
            return new SutureKit();
        }
        public override int killValue()
        {
            return 250; 
        }

        public InfectedDoctor()
        {
            attack = 3;
            health = 12;
            hitProbability = 2;
            playerExp = 4;
        }
        public override string battleGreeting()
        {
            return "The Infected Doctor is running towards you!";
        }

        //Description of the Rat attacking the player to display. We can write more these in this method
        //and make it so that random ones display each time. 
        public override string attackDescription()
        {
            return "\nThe Infected Doctor bites your arm!";
        }
    }
}
