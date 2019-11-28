﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class BackpackCommand : Command
    {

        public BackpackCommand()
        {
            this.name = "backpack";
        }

        public override bool execute(Player player)
        {
            if (player.Backpack != null)
            {
                NotificationCenter.Instance.postNotification(new Notification("PushBackpackCommands", this));
                player.outputMessage(player.Backpack.displayItems()); 
                return false;
            }
            else
            {
                player.outputMessage("I have no backpack!");
                return false;
            }
        }
    }
}
