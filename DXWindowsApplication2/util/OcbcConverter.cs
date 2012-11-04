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
            char[] delimiterChars = {'\n', '\t'};
            var splitList = testString.Split(delimiterChars).ToList();
            int i = 0;
            while(i<splitList.Count-2){
                var temp = new Expense();
                temp.Time = System.Convert.ToDateTime(splitList[i++]);
                i++;
                var format = new string []{"dd/MM/yyyy"};
                var tempIndex = i;

                while (tempIndex < splitList.Count)
                {
                    DateTime datetime;
                    if (DateTime.TryParseExact(splitList[tempIndex], format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                    {
                        tempIndex--;
                        break;
                    }
                    tempIndex++;

                }
                if (tempIndex >= splitList.Count) tempIndex = splitList.Count - 1;
                if(splitList[tempIndex].Trim() == "-")
                {
                    temp.IsExpense = true;
                    temp.Value = System.Convert.ToDouble((splitList[tempIndex-1].Trim()));
                    
                }
                else
                {
                    temp.IsExpense = false;
                    temp.Value = System.Convert.ToDouble((splitList[tempIndex].Trim()));
                }
                temp.Description = JoinDescriptionFromArray(splitList, i, tempIndex - 2);

                i = tempIndex+1;

                result.Add(temp);
            }
            return result;
        }

        public string JoinDescriptionFromArray(List<String> arrayString, int startIndex, int endIndex)
        {
            String result = "";
            for (int i = startIndex; i <= endIndex;i++ )
            {
                result += arrayString[i].Trim() + " ";
            }
            return result.Trim();
        }
    }
}
