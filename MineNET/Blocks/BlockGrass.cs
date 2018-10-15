﻿using MineNET.Items;

namespace MineNET.Blocks
{
    public class BlockGrass : BlockSolid
    {
        public BlockGrass() : base(BlockIDs.GRASS, "Glass")
        {
            this.Hardness = 0.6f;
            this.Resistance = 3f;
            this.ToolType = ItemToolType.SHOVEL;
        }
    }
}
