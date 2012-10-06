using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXWindowsApplication2.Model;
using NUnit.Framework;
using DXWindowsApplication2.util;
namespace ClassLibrary1
{
    [TestFixture]
    public class ConvertToJsonTest
    {
        ConvertToJson _converter;
        private List<Expense> listObj = new List<Expense>();



        [SetUp]
        public void Setup()
        {
            _converter = new ConvertToJson(ProjectEnvironment.FILEPATH);
            listObj.Add(new Expense("food", "lunch", 5, true, new DateTime(2012, 9, 14)));
            listObj.Add(new Expense("food", "diner", 4, true, new DateTime(2012, 9, 15)));
            listObj.Add(new Expense("cloth", "g200", 40, true, new DateTime(2012, 10, 5)));
            listObj.Add(new Expense("loan", "borrow from a", 10, false, new DateTime(2012, 9, 10)));
        }

        [Test]
        public void WriteToFile()
        {
            _converter.WriteToFile(listObj);
//            var result = _converter.Serialized(listObj);
//            var deserializedResult = _converter.Deserialized<List<Expense>>(result);
//            foreach (Expense expense in deserializedResult)
//            {
//                Console.WriteLine(expense.ToString());
//            }
        }
        [Test]
        public void ReadFromFile()
        {
            var content = _converter.ReadFromFile();
            foreach (var expense in content)
            {
                Console.WriteLine(expense.ToString());
            }
        }
    }
}
