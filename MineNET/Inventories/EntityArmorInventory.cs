﻿using MineNET.Data;
using MineNET.Entities;
using MineNET.Entities.Players;
using MineNET.Items;
using MineNET.Network.MinecraftPackets;

namespace MineNET.Inventories
{
    public class EntityArmorInventory : BaseInventory
    {
        public const int SLOT_ARMOR_HEAD = 0;
        public const int SLOT_ARMOR_CHEST = 1;
        public const int SLOT_ARMOR_LEGS = 2;
        public const int SLOT_ARMOR_FEET = 3;

        public EntityArmorInventory(EntityLiving entity) : base(entity)
        {
        }

        public override int Size
        {
            get
            {
                return 4;
            }
        }

        public override byte Type
        {
            get
            {
                return ContainerIds.ARMOR.GetIndex();
            }
        }

        public override string Name
        {
            get
            {
                return "Armor";
            }
        }

        public override void SendSlot(int index, params Player[] players)
        {
            base.SendSlot(index, players);
            this.SendArmorContents(this.Holder.Viewers);
        }

        public override void SendContents(params Player[] players)
        {
            base.SendContents(players);
            this.SendArmorContents(this.Holder.Viewers);
        }

        public void SendArmorContents(params Player[] players)
        {
            for (int i = 0; i < players.Length; ++i)
            {
                MobArmorEquipmentPacket pk = new MobArmorEquipmentPacket
                {
                    EntityRuntimeId = this.Holder.EntityID,
                    Items = this.GetArmorContents()
                };
                players[i].SendPacket(pk);
            }
        }

        public Item[] GetArmorContents()
        {
            return new Item[] {
                this.Helmet,
                this.ChestPlate,
                this.Leggings,
                this.Boots,
            };
        }

        public void SetArmorContents(Item[] items)
        {
            for (int i = 0; i < items.Length; ++i)
            {
                this.SetItem(i, items[i]);
            }
        }

        public new EntityLiving Holder
        {
            get
            {
                return (EntityLiving) base.Holder;
            }

            protected set
            {
                base.Holder = value;
            }
        }

        public Item Helmet
        {
            get
            {
                return this.GetItem(EntityArmorInventory.SLOT_ARMOR_HEAD);
            }

            set
            {
                this.SetItem(EntityArmorInventory.SLOT_ARMOR_HEAD, value);
            }
        }

        public Item ChestPlate
        {
            get
            {
                return this.GetItem(EntityArmorInventory.SLOT_ARMOR_CHEST);
            }

            set
            {
                this.SetItem(EntityArmorInventory.SLOT_ARMOR_CHEST, value);
            }
        }

        public Item Leggings
        {
            get
            {
                return this.GetItem(EntityArmorInventory.SLOT_ARMOR_LEGS);
            }

            set
            {
                this.SetItem(EntityArmorInventory.SLOT_ARMOR_LEGS, value);
            }
        }

        public Item Boots
        {
            get
            {
                return this.GetItem(EntityArmorInventory.SLOT_ARMOR_FEET);
            }

            set
            {
                this.SetItem(EntityArmorInventory.SLOT_ARMOR_FEET, value);
            }
        }
    }
}
