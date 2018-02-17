﻿using System;

namespace MineNET.NBT.Tags
{
    public class DoubleTag : DataTag<double>
    {
        public override NBTTagType TagType
        {
            get
            {
                return NBTTagType.DOUBLE;
            }
        }

        public DoubleTag(double data) : this("", data)
        {

        }

        public DoubleTag(string name, double data) : base(name, data)
        {

        }

        public override string ToString()
        {
            return $"DoubleTag : Name {this.Name}  : Data {this.Data}";
        }

        internal override void Write(NBTStream stream)
        {
            throw new NotImplementedException();
        }

        internal override void WriteTag(NBTStream stream)
        {
            throw new NotImplementedException();
        }

        internal override void Read(NBTStream stream)
        {
            throw new NotImplementedException();
        }

        internal override void ReadTag(NBTStream stream)
        {
            throw new NotImplementedException();
        }
    }
}