﻿using MineNET.NBT.Data;
using MineNET.NBT.IO;

namespace MineNET.NBT.Tags
{
    public class FloatTag : DataTag<float>
    {
        public override NBTTagType TagType
        {
            get
            {
                return NBTTagType.FLOAT;
            }
        }

        public FloatTag(float data) : this("", data)
        {

        }

        public FloatTag(string name, float data) : base(name, data)
        {

        }

        public override string ToString()
        {
            return $"FloatTag : Name {this.Name} : Data {this.Data}";
        }

        internal override void Write(NBTStream stream)
        {
            stream.WriteFloat(this.Data);
        }

        internal override void WriteTag(NBTStream stream)
        {
            stream.WriteByte((byte) this.TagType);
            stream.WriteString(this.Name);
            this.Write(stream);
        }

        internal override void Read(NBTStream stream)
        {
            this.Data = stream.ReadFloat();
        }

        internal override void ReadTag(NBTStream stream)
        {
            stream.ReadByte();
            this.Name = stream.ReadString();
            this.Read(stream);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FloatTag))
            {
                return false;
            }
            FloatTag tag = (FloatTag) obj;
            if (this.Name != tag.Name)
            {
                return false;
            }
            if (this.Data != tag.Data)
            {
                return false;
            }
            return true;
        }

        public static bool operator ==(FloatTag A, FloatTag B)
        {
            return A.Equals(B);
        }

        public static bool operator !=(FloatTag A, FloatTag B)
        {
            return !A.Equals(B);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}