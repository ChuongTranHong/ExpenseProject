using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Resources;
using System.Windows.Forms;
using DXWindowsApplication2.Controller;
using DXWindowsApplication2.Model;
using DXWindowsApplication2.util;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;

namespace DXWindowsApplication2.view
{
    public partial class MainPageView : XtraForm
    {
        private readonly MainPageController _controller;

        public MainPageView(IController controller)
        {
            _controller = (MainPageController)controller;
            _controller.SetView(this);
            InitializeComponent();
            InitSkinGallery();
            _controller.OnLoad();
            RegisterListener();
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        public void SetGrid(BindingList<Expense> grid)
        {
            gridControl.DataSource = grid;
        }

        private void RegisterListener()
        {
            newItemButton.ItemClick += NewItemButtonItemClick;
            gridControl.EmbeddedNavigator.ButtonClick += GridControlClick;
            saveButton.ItemClick += SaveButtonItemClick;
            exitButton.ItemClick += CloseApplication;
            pasteButton.ItemClick += PasteButtonItemClick;
            var dataSource = (BindingList<Expense>)gridControl.DataSource;
            dataSource.ListChanged += HandleDataSourceChange;
        }

        private void PasteButtonItemClick(object sender, ItemClickEventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();
            // If the data is text, then set the text of the 
            // TextBox to the text in the Clipboard.
            var converter = new OcbcConverter();
            if (data.GetDataPresent(DataFormats.Text))
            {
                List<Expense> expenses = converter.Convert(data.GetData(DataFormats.Text).ToString());
                foreach( var expense in expenses)
                {
                    _controller.AddExpense(expense);
                }

            }
        }

        private void NewItemButtonItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm newForm = new NewExpenseView(new NewExpenseController());
            newForm.Owner = this;
            newForm.Show();
        }

        private void CloseApplication(object sender, ItemClickEventArgs itemClickEventArgs)
        {
            Close();
        }

        public void AddExpense(Expense expense)
        {
            _controller.AddExpense(expense);
        }

        private void GirdHasChanged()
        {
            _controller.SetGridChanged();
        }

        private void GridControlClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType != NavigatorButtonType.Edit) return;
            EditRecord();
            e.Handled = true;
        }

        private void EditRecord()
        {
            var focusedRow = gridView1.FocusedRowHandle;
            var expense = (Expense)gridView1.GetRow(focusedRow);
            var newExpenseView = new NewExpenseView(expense);
            newExpenseView.Show(this);
        }

        private bool AddRecord()
        {
            var newExpenseView = new NewExpenseView(new NewExpenseController());
            newExpenseView.Show(this);
            return true;
        }

        private void SaveButtonItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_controller.GridIsChanged) return;
            SaveChangeToFile();
        }

        private void HandleDataSourceChange(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            GirdHasChanged();
        }

        public void HandleClosing(object sender, FormClosingEventArgs e)
        {
            if (!_controller.GridIsChanged) return;
            var result = XtraMessageBox.Show("Do you want to save the changes ?", "Expense",
                                             MessageBoxButtons.YesNoCancel);
            switch(result)
            {
                case DialogResult.Yes:
                    SaveChangeToFile();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void SaveChangeToFile()
        {
            var dataSource = (BindingList<Expense>)gridControl.DataSource;
            _controller.SaveDataFromGridToFile(dataSource);
        }
    }
}