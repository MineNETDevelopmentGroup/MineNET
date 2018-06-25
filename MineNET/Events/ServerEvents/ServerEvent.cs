﻿using System;

namespace MineNET.Events.ServerEvents
{
    public class ServerEvent
    {
        public event EventHandler<ServerStartEventArgs> ServerStart;
        public void OnServerStart(object sender, ServerStartEventArgs e)
        {
            this.ServerStart?.Invoke(sender, e);
        }

        public event EventHandler<ServerStopEventArgs> ServerStop;
        public void OnServerStop(object sender, ServerStopEventArgs e)
        {
            this.ServerStop?.Invoke(sender, e);
        }

        public event EventHandler<ServerCommandEventArgs> ServerCommand;
        public void OnServerCommand(object sender, ServerCommandEventArgs e)
        {
            this.ServerCommand?.Invoke(sender, e);
        }
    }
}
