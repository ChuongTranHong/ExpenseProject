using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DXWindowsApplication2.Model;
using DXWindowsApplication2.util;
using NUnit.Framework;
namespace ClassLibrary1.util
{
    [TestFixture]
    class DbsConverterTest
    {
        readonly DbsConverter _converter = new DbsConverter();

        [Test]
        public void ShouldConvertOneExpense()
        {
            const string testString = "31 Oct 2012 \tINT \t  \t \tS$0.07 ";
            var expenses = _converter.Convert(testString);
            Assert.AreEqual(1, expenses.Count);
            AssertExpenseDetail(expenses[0], new DateTime(2012, 10, 31), "", 0.07, false);
        }

        private static void AssertExpenseDetail(Expense expense,DateTime time, String description, double value, bool isExpense)
        {
            Assert.AreEqual(time, expense.Time);
            Assert.AreEqual(description, expense.Description);
            Assert.AreEqual(value, expense.Value);
            Assert.AreEqual(isExpense,expense.IsExpense);
        }

        [Test]
        public void TestShouldConvertManyExpense()
        {
            const string testString =
                "31 Oct 2012 \tINT \t  \t \tS$0.07 \r\n27 Oct 2012 \tMST \t00.30 % CASHBACK 24OCT 4628-4500-1199-0463  \tS$2.80 \t ";
            var expenses = _converter.Convert(testString);
            Assert.AreEqual(2, expenses.Count);
            AssertExpenseDetail(expenses[0], new DateTime(2012, 10, 31), "", 0.07, false);
            AssertExpenseDetail(expenses[1], new DateTime(2012, 10, 27), "00.30 % CASHBACK 24OCT 4628-4500-1199-0463", 2.80, true);
        }
        [Test]
        public void ConvertCurrency()
        {
            var value = Double.Parse( "$50.00", NumberStyles.Currency);
            Assert.AreEqual(50, value);
        }
    }



}
