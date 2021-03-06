﻿namespace MineNET.Network.MinecraftPackets
{
    public class NpcRequestPacket : MinecraftPacket
    {
        public override byte PacketID { get; } = MinecraftProtocol.NPC_REQUEST_PACKET;

        public long EntityRuntimeId { get; set; }
        public byte RequestType { get; set; }
        public string CommandString { get; set; }
        public byte ActionType { get; set; }

        protected override void EncodePayload()
        {
            this.WriteEntityRuntimeId(this.EntityRuntimeId);
            this.WriteByte(this.RequestType);
            this.WriteString(this.CommandString);
            this.WriteByte(this.ActionType);
        }

        protected override void DecodePayload()
        {
            this.EntityRuntimeId = this.ReadEntityRuntimeId();
            this.RequestType = this.ReadByte();
            this.CommandString = this.ReadString();
            this.ActionType = this.ReadByte();
        }
    }
}
