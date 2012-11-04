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
    class OcbcConverterTest

    {
        readonly IConverter _converter = new OcbcConverter();

        [Test]
        public void ShouldConvertToExpenseDataToExpenseType()
        {
            const string testString = "26/10/2012\t27/10/2012\tCASH WITHDRAWAL ATM\t600.00\t-";
            var result = _converter.Convert(testString);
            var expense = result[0];
            Assert.AreEqual("CASH WITHDRAWAL ATM", expense.Description);
            Assert.AreEqual(600.0, expense.Value);
            Assert.IsTrue(expense.IsExpense);
            Assert.AreEqual(new DateTime(2012,10,26),expense.Time);
        }

        [Test]
        public void ShouldConvertToExpenseDataToNotExpenseType()
        {
            const string testString = "26/10/2012\t27/10/2012\tCASH WITHDRAWAL ATM\t-\t600.00";
            var result = _converter.Convert(testString);
            var expense = result[0];
            Assert.AreEqual("CASH WITHDRAWAL ATM", expense.Description);
            Assert.AreEqual(600.0, expense.Value);
            Assert.IsFalse(expense.IsExpense);
            Assert.AreEqual(new DateTime(2012, 10, 26), expense.Time);
        }

        [Test]
        public void TestMultipleExpenseConverter()
        {
            const string testString = "26/10/2012\t27/10/2012\tCASH WITHDRAWAL ATM\t600.00\t-\n26/10/2012\t27/10/2012\tCASH WITHDRAWAL ATM\n123\t-\t1,000.00\n26/10/2012\t27/10/2012\tCASH WITHDRAWAL ATM\t600.00\t-\n";
            List<Expense> result = _converter.Convert(testString);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("CASH WITHDRAWAL ATM",result[0].Description);
            Assert.AreEqual(600,result[0].Value);
            Assert.AreEqual(new DateTime(2012,10,26), result[0].Time);
            Assert.IsTrue(result[0].IsExpense);
            Assert.AreEqual("CASH WITHDRAWAL ATM\n123",result[1].Description);
            Assert.AreEqual(1000, result[1].Value);
            Assert.AreEqual(new DateTime(2012,10,26), result[1].Time);
            Assert.IsFalse(result[1].IsExpense);
            Assert.AreEqual("CASH WITHDRAWAL ATM", result[2].Description);
            Assert.AreEqual(600, result[2].Value);
            Assert.AreEqual(new DateTime(2012, 10, 26), result[2].Time);
            Assert.IsTrue(result[2].IsExpense);
        }

    }

}

