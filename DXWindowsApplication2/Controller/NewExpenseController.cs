using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXWindowsApplication2.util;
using DXWindowsApplication2.view;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace DXWindowsApplication2.Controller
{
    class NewExpenseController:IController
    {
        private NewExpenseView _expenseView;
        public void OnLoad()
        {
            LoadFieldDropDown();
        }

        public void SetView(XtraForm view)
        {
            _expenseView = (NewExpenseView)view;
        }
        private void LoadFieldDropDown()
        {
            var dropDown = _expenseView.FieldDropDown;
            var dropDownCollection = dropDown.Properties.Items;
            dropDownCollection.BeginUpdate();
            var fieds = XmlUtil.ReadFromFile("Setting/DefaultSetting.xml", "Fields");
            foreach (var fied in fieds)
            {
                dropDownCollection.Add(fied);
            }
            dropDownCollection.EndUpdate();

        }
       
    }
}
