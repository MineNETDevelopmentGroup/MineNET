﻿namespace MineNET.Items
{
    public abstract class ItemFood : Item
    {
        public ItemFood(int id) : base(id)
        {

        }

        public override bool CanBeConsumed
        {
            get
            {
                return true;
            }
        }

        //TODO: public override void OnConsume(Entity entity) EntityEatItemEvent
    }
}