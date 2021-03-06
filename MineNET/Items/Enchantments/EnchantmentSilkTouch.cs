﻿namespace MineNET.Items.Enchantments
{
    public class EnchantmentSilkTouch : Enchantment
    {
        public override int ID
        {
            get
            {
                return Enchantment.SILK_TOUCH;
            }
        }

        public override int MinLevel
        {
            get
            {
                return 1;
            }
        }

        public override int MaxLevel
        {
            get
            {
                return 1;
            }
        }

        public override int Weight
        {
            get
            {
                return 1;
            }
        }

        public override string Name
        {
            get
            {
                return "enchantment.silk_touch";
            }
        }
    }
}
