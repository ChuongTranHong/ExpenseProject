using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXWindowsApplication2.Model;

namespace DXWindowsApplication2.util
{
    public class OcbcConverter : IConverter
    {
        public List<Expense> Convert(string testString)
        {
            var result = new List<Expense>();
            List<String> splitList = testString.Split('\t').ToList();
            for (int i = 0; i < splitList.Count; i++)
            {
                var temp = new Expense();
                temp.Time = System.Convert.ToDateTime(splitList[i++]);
                i++;
                temp.Description = splitList[i++];
                if (splitList[i].Trim() != "-")
                {
                    temp.IsExpense = true;
                    temp.Value = System.Convert.ToDouble(splitList[i].Trim());
                    var incomeValue = splitList[++i];

                    var splitIncomeValue = incomeValue.Split('\n');
                    if (i != (splitList.Count - 1))
                        splitList.Insert(i + 1, splitIncomeValue[1]);

                }
                else
                {
                    temp.IsExpense = false;
                    var splitIncomeValue = splitList[++i].Split('\n');
                    temp.Value = System.Convert.ToDouble((splitIncomeValue[0].Trim()));
                    if (i != (splitList.Count - 1))
                    {
                        splitList.Insert(i + 1, splitIncomeValue[1]);
                    }
                }
                result.Add(temp);
            }
            return result;
        }
    }
}
