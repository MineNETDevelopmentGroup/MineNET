﻿using System;

namespace MineNET.Utils.Config
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class YamlDescriptionAttribute : Attribute
    {
        public YamlDescriptionAttribute(string description)
        {
            this.Description = description;
            this.IsInline = false;
        }

        public string Description
        {
            get;
        }

        public bool IsInline
        {
            get;
        }
    }
}