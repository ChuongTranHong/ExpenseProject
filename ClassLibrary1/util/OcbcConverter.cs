using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXWindowsApplication2.Model;
using DXWindowsApplication2.util;
using NUnit.Framework;
namespace ClassLibrary1.util
{
    [TestFixture]
    internal class OcbcConverterTest
    {
        private readonly OcbcConverter _converter = new OcbcConverter();

        [Test]
        public void ShouldConvertToExpenseDataToExpenseType()
        {
            const string testString = "04/11/2012\t 05/11/2012\t3RD PTY TRANSFER INB\r\nChuong\r\n80.00\t -";
            var result = _converter.Convert(testString);
            var expense = result[0];
            Assert.AreEqual("3RD PTY TRANSFER INB Chuong", expense.Description);
            Assert.AreEqual(80, expense.Value);
            Assert.IsTrue(expense.IsExpense);
            Assert.AreEqual(new DateTime(2012, 11, 4), expense.Time);
        }

      

        [Test]
        public void TestMultipleExpenseConverter()
        {
            const string testString =
                "04/11/2012\t 05/11/2012\t3RD PTY TRANSFER INB\r\nChuong\r\n80.00\t -\r\n02/11/2012\t 02/11/2012\t3RD PTY TRANSFER INB\r\nTMPhuong\r\n-\t 50";
            List<Expense> result = _converter.Convert(testString);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("3RD PTY TRANSFER INB Chuong", result[0].Description);
            Assert.AreEqual(80, result[0].Value);
            Assert.AreEqual(new DateTime(2012, 11, 4), result[0].Time);
            Assert.IsTrue(result[0].IsExpense);
            Assert.AreEqual("3RD PTY TRANSFER INB TMPhuong", result[1].Description);
            Assert.AreEqual(50, result[1].Value);
            Assert.AreEqual(new DateTime(2012, 11, 2), result[1].Time);
            Assert.IsFalse(result[1].IsExpense);
        }

        [Test]
        public void testSplitString()
        {
            const string testString = "3RD PTY TRANSFER INB\r\nChuong\r\n80.00\t -";
            char[] delimiterChars = {'\n', '\t'};
            var sliptList = testString.Split(delimiterChars).ToList();
            foreach (var eachValue in sliptList)
            {
                Console.WriteLine(eachValue);
            }

        }

        [Test]
        public void testJoinDescirption()
        {
            var array = new List<string>{"test", "string\r", "value","dummy"};
            var resutl = _converter.JoinDescriptionFromArray(array, 1, 2);
            Assert.AreEqual("string value", resutl);
        }

    }

}

