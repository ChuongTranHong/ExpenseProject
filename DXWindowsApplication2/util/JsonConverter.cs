using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DXWindowsApplication2.Model;
using Newtonsoft.Json;
namespace DXWindowsApplication2.util
{
    public class ConvertToJson
    {
        public string Path { get; set; }

        public ConvertToJson(string path)
        {
            Path = path;
        }

        public string Serialized<T>(T objList)
        {
            var oSerializer =
                JsonConvert.SerializeObject(objList, Formatting.Indented);
            return oSerializer;
        }
        public T Deserialized<T>(string jsonValue)
        {
            return JsonConvert.DeserializeObject<T>(jsonValue);
        }
        public void WriteToFile(List<Expense> objList)
        {
            string json = Serialized < List<Expense>>(objList);
            using (var file = new StreamWriter(Path))
            {
                file.WriteLine(json);
            }
        } 
        
        public List<Expense> ReadFromFile()
        {
            string content = File.ReadAllText(Path);
            return Deserialized<List<Expense>>(content);
        }
    }
}
