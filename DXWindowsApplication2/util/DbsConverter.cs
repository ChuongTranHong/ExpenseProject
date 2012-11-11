using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DXWindowsApplication2.Model;

namespace DXWindowsApplication2.util
{
    public class DbsConverter : IConverter
    {
        public List<Expense> Convert(string testString)
        {
            var result = new List<Expense>();
            char[] delimiterChars = { '\n', '\t' };
            var splitList = testString.Split(delimiterChars).ToList();
            for (var i = 0; i < splitList.Count-4; i++)
            {
                var newExpense = new Expense();
                var actualDateTime = splitList[i++].Trim();
                var ignoreExpenseCode = splitList[i++].Trim();
                var actualDescription = splitList[i++].Trim();
                var actualDebit = splitList[i++].Trim();
                var actualCredit = splitList[i].Trim();

                newExpense.Time = System.Convert.ToDateTime(actualDateTime);
                newExpense.Description = actualDescription;
                if (actualDebit != "")
                {
                    ExtractExpenseValue(newExpense, actualDebit, true);
                }
                else
                {
                    ExtractExpenseValue(newExpense, actualCredit, false);
                }
                result.Add(newExpense);
            }
            return result;
        }

        private static void ExtractExpenseValue(Expense newExpense, string stringValue, bool isExpense)
        {
            var removeSingaporeDollarSymbol = stringValue.Substring(1, stringValue.Length - 1);
            newExpense.IsExpense = isExpense;
            newExpense.Value = Double.Parse(removeSingaporeDollarSymbol, NumberStyles.Currency);
        }
    }
}
