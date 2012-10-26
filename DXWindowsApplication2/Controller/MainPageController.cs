using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DXWindowsApplication2.Model;
using DXWindowsApplication2.util;
using DXWindowsApplication2.view;
using DevExpress.XtraEditors;
using Environment = DXWindowsApplication2.util.ProjectEnvironment;

namespace DXWindowsApplication2.Controller
{
    class MainPageController:IController
    {
        private MainPageView _form;
        private readonly BindingList<Expense> _gridData = new BindingList<Expense>();
        private bool _gridIsChanged = false;

        public bool GridIsChanged
        {
            get { return _gridIsChanged; }
        }

        public void OnLoad()
        {
            InitGrid();
        }

        public void SetView(XtraForm view)
        {
            _form = (MainPageView)view;
        }

        private void InitGrid()
        {
            var convertor = new ConvertToJson(ProjectEnvironment.FILEPATH);
            var readData = convertor.ReadFromFile();
            foreach (var expense in readData)
            {
                _gridData.Add(expense);
            }
            _form.SetGrid(_gridData);
        }

        public void AddExpense(Expense expense)
        {
            _gridData.Add(expense);
        }

        public void SetGridChanged()
        {
            _gridIsChanged = true;
        }

        public void SaveDataFromGridToFile(BindingList<Expense> dataSource)
        {
            var convertor = new ConvertToJson(ProjectEnvironment.FILEPATH);
            convertor.WriteToFile(dataSource);
        }
   
    }
}

