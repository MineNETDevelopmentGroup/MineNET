﻿using System.IO;
using System.Threading.Tasks;
using MineNET.Inventories;
using MineNET.Items;
using MineNET.NBT.Data;
using MineNET.NBT.IO;
using MineNET.NBT.Tags;
using MineNET.Worlds;

namespace MineNET.Entities.Players
{
    public partial class Player
    {
        public Player()
        {
            this.ShowNameTag = true;
            this.AlwaysShowNameTag = true;

            this.SetFlag(Entity.DATA_FLAGS, Entity.DATA_FLAG_CAN_CLIMB);
        }

        private void LoadData()
        {
            string path = $"{Server.ExecutePath}\\players\\{this.Name}.dat";
            if (!File.Exists(path))
            {
                NBTIO.WriteGZIPFile(path, new CompoundTag(), NBTEndian.BIG_ENDIAN);
                this.RegisterData();
            }
            else
            {
                this.namedTag = NBTIO.ReadGZIPFile(path, NBTEndian.BIG_ENDIAN);
            }

            this.Inventory = new PlayerInventory(this);
        }

        private void RegisterData()
        {
            CompoundTag item = NBTIO.WriteItem(Item.Get(0));
            this.namedTag = new CompoundTag();
            this.namedTag.PutList(new ListTag<CompoundTag>("Attributes"));

            this.namedTag.PutList(new ListTag<FloatTag>("Pos"));
            this.namedTag.PutList(new ListTag<FloatTag>("Rotation"));

            this.namedTag.PutInt("PlayerGameMode", int.Parse(Server.ServerConfig.GameMode));//TODO Parse Error...
            this.namedTag.PutInt("PlayerLevel", 0);
            this.namedTag.PutFloat("PlayerLevelProgress", 0f);
        }

        private int FixRadius(int radius)
        {
            int maxRequest = Server.ServerConfig.MaxViewDistance;
            if (radius > maxRequest) radius = maxRequest;
            return radius;
        }

        internal override void OnUpdate()
        {
            if (this.HasSpawned)
            {
                Task.Run(() =>
                {
                    foreach (Chunk chunk in this.World.LoadChunks(this.GetChunkVector(), this.RequestChunkRadius))
                    {
                        chunk.SendChunk(this);
                    }
                });
            }
        }
    }
}
