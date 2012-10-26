using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using DXWindowsApplication2.Model;
using Newtonsoft.Json;
namespace DXWindowsApplication2.util
{
    public class ConvertToJson
    {
        private string Path { get; set; }

        public ConvertToJson(string path)
        {
            Path = path;
        }

        private string Serialized<T>(T objList)
        {
            var oSerializer =
                JsonConvert.SerializeObject(objList, Formatting.Indented);
            return oSerializer;
        }

        private T Deserialized<T>(string jsonValue)
        {
            return JsonConvert.DeserializeObject<T>(jsonValue);
        }

        public void WriteToFile(BindingList<Expense> objList)
        {
            string json = Serialized (objList);
            using (var file = new StreamWriter(Path))
            {
                file.WriteLine(json);
            }
        } 
        
        public IEnumerable<Expense> ReadFromFile()
        {
            string content = File.ReadAllText(Path);
            return Deserialized<List<Expense>>(content);
        }
    }
}
