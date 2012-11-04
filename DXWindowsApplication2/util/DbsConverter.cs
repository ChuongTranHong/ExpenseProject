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
            var splitList = testString.Split('\t').ToList();
            for (var i = 0; i < splitList.Count; i++)
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
                    newExpense.IsExpense = true;
                    ExtractExpenseValue(newExpense, actualDebit);
                    var splitIncomeValue = actualCredit.Split('\n');
                    CheckForTheEndOfSplitList(splitIncomeValue, splitList, i);

                }
                else
                {
                    newExpense.IsExpense = false;
                    var splitIncomeValue = actualCredit.Split('\n');
                    ExtractExpenseValue(newExpense, actualCredit);
                    CheckForTheEndOfSplitList(splitIncomeValue, splitList, i);
                }
                result.Add(newExpense);
            }
            return result;
        }

        private static void ExtractExpenseValue(Expense newExpense, string stringValue)
        {
            var removeSingaporeDollarSymbol = stringValue.Substring(1, stringValue.Length - 1);
            newExpense.Value = Double.Parse(removeSingaporeDollarSymbol, NumberStyles.Currency);
        }

        private static void CheckForTheEndOfSplitList(string[] splitIncomeValue, List<string> splitList, int i)
        {
            if (i != (splitList.Count - 1))
                splitList.Insert(i + 1, splitIncomeValue[splitIncomeValue.Length - 1]);
        }
    }
}
