using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXWindowsApplication2.view;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace DXWindowsApplication2.Controller
{
    class NewExpenseController:IController
    {
        private NewExpense _expenseView;
        public void OnLoad()
        {
            LoadFieldDropDown();
        }

        public void SetView(XtraForm view)
        {
            _expenseView = (NewExpense)view;
        }
        private void LoadFieldDropDown()
        {
            ComboBoxEdit dropDown = _expenseView.FieldDropDown;
            ComboBoxItemCollection dropDownCollection = dropDown.Properties.Items;
            dropDownCollection.BeginUpdate();
            try
            {
                dropDownCollection.Add("Food and Drink");
                dropDownCollection.Add("Clothes");
                dropDownCollection.Add("Utilities");
                dropDownCollection.Add("Entertainment");
                dropDownCollection.Add("Home/Rent");
                dropDownCollection.Add("Misc");

            }
            finally
            {
                dropDownCollection.EndUpdate();
            }
        }
       
    }
}
