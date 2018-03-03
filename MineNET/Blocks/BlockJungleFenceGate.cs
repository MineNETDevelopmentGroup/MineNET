﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Blocks
{
    public class BlockJungleFenceGate : BlockFenceGateBase
    {
        public BlockJungleFenceGate() : base(BlockFactory.JUNGLE_FENCE_GATE)
        {

        }

        public override string Name
        {
            get
            {
                return "JungleFenceGate";
            }
        }
    }
}
