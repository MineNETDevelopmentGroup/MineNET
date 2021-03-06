﻿using MineNET.Commands.Data;
using MineNET.Commands.Parameters;
using MineNET.Entities.Players;
using MineNET.Text;

namespace MineNET.Commands.Defaults
{
    public class TellCommand : Command
    {
        public override string Name
        {
            get
            {
                return "tell";
            }
        }

        public override string Description
        {
            get
            {
                return "%commands.tell.description";
            }
        }

        public override string[] Aliases
        {
            get
            {
                return new string[] { "w", "msg" };
            }
        }

        public override CommandOverload[] CommandOverloads
        {
            get
            {
                return new CommandOverload[]
                {
                    new CommandOverload(
                        new CommandParameterTarget("target", true),
                        new CommandParameterMessage("message", true)
                    )
                };
            }
        }

        public override bool OnExecute(CommandSender sender, string command, params string[] args)
        {
            if (args.Length < 2)
            {
                this.SendLengthErrorMessage(sender, command, args, args.Length);
                return false;
            }

            if (args[0] == "@e")
            {
                this.SendTargetNotPlayerMessage(sender);
                return false;
            }

            Player[] players = this.GetPlayerFromSelector(args[0], sender);
            if (players == null)
            {
                this.SendNoTargetMessage(sender);
                return false;
            }

            for (int i = 0; i < players.Length; ++i)
            {
                players[i].SendMessage(new TranslationContainer("commands.message.display.incoming", sender.Name, args[1]));
                sender.SendMessage(new TranslationContainer("commands.message.display.outgoing", sender.Name, args[1]));
            }
            return true;
        }
    }
}
