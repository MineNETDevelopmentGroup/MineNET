﻿namespace MineNET.Network.MinecraftPackets
{
    public class ServerSettingsRequestPacket : MinecraftPacket
    {
        public override byte PacketID { get; } = MinecraftProtocol.SERVER_SETTINGS_REQUEST_PACKET;

        protected override void EncodePayload()
        {

        }

        protected override void DecodePayload()
        {

        }
    }
}
