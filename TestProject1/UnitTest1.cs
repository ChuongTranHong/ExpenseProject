using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using DXWindowsApplication2.util;
using Assert = NUnit.Framework.Assert;

namespace TestProject1
{
    [TestFixture]
    public class ConvertToJsonTest
    {
        [SetUp]
        public void setup()
        {

            new ConvertToJson("abdfde");
        }

        [Test]
        public void WriteToFile()
        {

            Assert.AreEqual(3, 3);
        }
    }
}
