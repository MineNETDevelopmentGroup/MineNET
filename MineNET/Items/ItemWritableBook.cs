﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Items
{
    public class ItemWritableBook : Item
    {
        public ItemWritableBook() : base(ItemFactory.WRITABLE_BOOK)
        {

        }

        public override string Name
        {
            get
            {
                return "WritableBook";
            }
        }
    }
}