﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MineCraftPENetwork.Packets.RakNet
{
    public class DataPacket_4 : DataPacket
    {
        public new const byte ID = 0x84;

        public override byte GetID()
        {
            return ID;
        }
    }
}
