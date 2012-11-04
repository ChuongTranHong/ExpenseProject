using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXWindowsApplication2.Model;

namespace DXWindowsApplication2.util
{
    public interface IConverter
    {
        List<Expense> Convert(string testString);

    }


}
