using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXWindowsApplication2.Model;

namespace DXWindowsApplication2.util
{
    public class OcbcConverter : IConverter
    {
        readonly string[] _format = new string[] { "dd/MM/yyyy" };
        public List<Expense> Convert(string testString)
        {
            var result = new List<Expense>();
            char[] delimiterChars = {'\n', '\t'};
            var splitList = testString.Split(delimiterChars).ToList();
            var index = 0;

            while(index<splitList.Count-2){
                var expense = new Expense();
                DateTime datetime1;
                DateTime.TryParseExact(splitList[index++], _format, System.Globalization.CultureInfo.InvariantCulture,
                                       System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime1);

                expense.Time = datetime1;
                var tempIndex = SearchForTheNextDateTimeValue(++index, splitList);
                if (tempIndex >= splitList.Count) tempIndex = splitList.Count - 1;

                if(splitList[tempIndex].Trim() == "-")
                {
                    expense.IsExpense = true;
                    expense.Value = System.Convert.ToDouble((splitList[tempIndex-1].Trim()));
                }
                else
                {
                    expense.IsExpense = false;
                    expense.Value = System.Convert.ToDouble((splitList[tempIndex].Trim()));
                }

                expense.Description = JoinDescriptionFromArray(splitList, index, tempIndex - 2);
                index = tempIndex+1;
                result.Add(expense);
            }
            return result;
        }

        private int SearchForTheNextDateTimeValue(int index, List<string> stringList )
        {
            while (index < stringList.Count)
            {
                DateTime datetime;
                if (DateTime.TryParseExact(stringList[index], _format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                {
                    index--;
                    break;
                }
                index++;
            }
            return index;
        }

        public string JoinDescriptionFromArray(List<String> arrayString, int startIndex, int endIndex)
        {
            var result = "";
            for (var i = startIndex; i <= endIndex;i++ )
            {
                result += arrayString[i].Trim() + " ";
            }
            return result.Trim();
        }
    }
}
