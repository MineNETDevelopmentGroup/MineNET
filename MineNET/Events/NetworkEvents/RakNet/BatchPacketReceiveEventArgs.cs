﻿using MineNET.Entities.Players;
using MineNET.Network;
using MineNET.Network.RakNetPackets;

namespace MineNET.Events.NetworkEvents.RakNet
{
    public class RakNetBatchPacketReceiveEventArgs : NetworkEventArgs
    {
        public NetworkSession Session { get; }
        public Player Player { get; }
        public BatchPacket Packet { get; set; }
        public bool IsCancel { get; set; }

        public RakNetBatchPacketReceiveEventArgs(NetworkSession session, Player player, BatchPacket packet)
        {
            this.Session = session;
            this.Player = player;
            this.Packet = packet;
        }
    }
}
