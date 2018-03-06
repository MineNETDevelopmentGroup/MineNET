﻿using MineNET.Inventories;
using MineNET.NBT.IO;
using MineNET.NBT.Tags;
using MineNET.Values;

namespace MineNET.BlockEntities
{
    public class BlockEntityChest : BlockEntitySpawnable, InventoryHolder
    {
        private ChestInventory inventory;

        public BlockEntityChest(Position position, CompoundTag nbt = null) : base(position, nbt)
        {
            this.inventory = new ChestInventory(this);

            if (!this.namedTag.Exist("items"))
            {
                this.namedTag.PutList(new ListTag<CompoundTag>("items"));
            }

            ListTag<CompoundTag> items = this.namedTag.GetList<CompoundTag>("items");
            for (int i = 0; i < items.Count; ++i)
            {
                this.inventory.SetItem(i, NBTIO.ReadItem(items[i]));
            }
        }

        public override string Name
        {
            get
            {
                return "Chest";
            }
        }

        public Inventory GetInventory()
        {
            return this.inventory;
        }
    }
}