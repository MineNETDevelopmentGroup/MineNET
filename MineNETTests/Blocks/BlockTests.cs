﻿using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MineNET.Blocks.Tests
{
    [TestClass()]
    public class BlockTests
    {
        [TestMethod()]
        public void GetTest()
        {
            BlockFactory f = new BlockFactory();
            FieldInfo[] fields = f.GetType().GetFields();
            foreach (FieldInfo i in fields)
            {
                Console.WriteLine(i.GetValue(f));
            }

            Assert.IsTrue(true);
        }
    }
}