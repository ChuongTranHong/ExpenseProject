using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DXWindowsApplication2.util;
namespace ClassLibrary1.util
{
    [TestFixture]
    class XmlUtilTest
    {
        [Test]
        public void testReadFromFile()
        {
           var result = XmlUtil.ReadFromFile("Setting/Default.xml", "Fields");
            Assert.That(result,Is.EquivalentTo(new []{"Food and Drink","Clothes"}));
        }
    }
}
