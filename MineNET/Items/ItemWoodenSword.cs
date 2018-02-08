﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Items
{
    public class ItemWoodenSword : ItemTool
    {
        public ItemWoodenSword() : base(ItemFactory.WOODEN_SWORD)
        {

        }

        public override string Name
        {
            get
            {
                return "WoodenSword";
            }
        }

        public override bool IsSword
        {
            get
            {
                return true;
            }
        }
    }
}