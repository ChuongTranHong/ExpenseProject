using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;

namespace DXWindowsApplication2.Controller
{
    public interface IController
    {
        void OnLoad();
        void SetView(XtraForm view);
    }
}
