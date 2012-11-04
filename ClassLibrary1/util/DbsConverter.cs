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
            const string testString = "06 Oct 2012\tAWL\t11990463,BISHAN 13/514A\tS$50.00\t";
            var expenses = _converter.Convert(testString);
            Assert.AreEqual(1, expenses.Count);
            AssertExpenseDetail(expenses[0], new DateTime(2012, 10, 6), "11990463,BISHAN 13/514A", 50, true);
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
                "01 Nov 2012\tIBG\tBY :DBS CARD CENTRE PART/REF:DCC (LOAN) 000051885461\tS$500.00\t\n31 Oct 2012\tINT\t\t\tS$0.07";
            var expenses = _converter.Convert(testString);
            Assert.AreEqual(2, expenses.Count);
            AssertExpenseDetail(expenses[0], new DateTime(2012, 11, 1),
                                "BY :DBS CARD CENTRE PART/REF:DCC (LOAN) 000051885461", 500, true);
            AssertExpenseDetail(expenses[1], new DateTime(2012,10,31), "", 0.07, false );
        }
        [Test]
        public void ConvertCurrency()
        {
            var value = Double.Parse( "$50.00", NumberStyles.Currency);
            Assert.AreEqual(50, value);
        }
    }



}
