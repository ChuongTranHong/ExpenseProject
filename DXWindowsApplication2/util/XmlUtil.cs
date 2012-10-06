using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DXWindowsApplication2.util
{
    public static class XmlUtil
    {
        public static IEnumerable<string> ReadFromFile(string path,string field)
        {
            var doc = new XmlDocument();
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            doc.Load(fs);
            var xmlnode = doc.GetElementsByTagName(field);
            return (from XmlNode node in xmlnode from XmlNode childNode in node.ChildNodes select childNode.InnerText.Trim()).ToList();
        }
    }
}
