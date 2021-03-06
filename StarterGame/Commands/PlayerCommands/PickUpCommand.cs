﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class PickUpCommand : Command
    {

        public PickUpCommand()
        {
            this.name = "pick up";
        }

        /**
        * Command that tells the player to pick up an item.  
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            string item = "";
            if (this.Words.Count == 0)
            {
                player.outputMessage("\nPick up what?");
                return false;
            }
            if (player.Backpack == null)
            {
                player.outputMessage("\nWhere are you going to put this item?"); 
            }
            else
            {
                while (this.Words.Count > 0)
                {
                    item += this.Words.Dequeue() + " ";
                }
                item = item.TrimEnd();
                player.pickUpItem(item);
                player.outputMessage(player.currentRoom.description());
            }
            return false;
        }
    }
}
