﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class SellCommand : Command
    {
        public SellCommand()
        {
            this.name = "sell";
            this.CommandType = CommandType.MerchantCommand;
        }

        public override bool execute(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
