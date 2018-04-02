﻿using MineNET.Entities.Attributes;
using MineNET.Inventories;

namespace MineNET.Entities
{
    public abstract class EntityLiving : Entity, InventoryHolder
    {
        public Inventory Inventory { get; protected set; }

        public EntityAttributeDictionary Attributes { get; protected set; } = new EntityAttributeDictionary();

        public override void EntityInit()
        {
            this.Attributes.AddAttribute();
        }
    }
}
