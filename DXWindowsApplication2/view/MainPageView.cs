﻿using System.ComponentModel;
using System.Windows.Forms;
using DXWindowsApplication2.Controller;
using DXWindowsApplication2.Model;
using DXWindowsApplication2.util;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraNavBar;

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
            calendarPanel.SetupCalendarControll(navigateCalendar);
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
            ocbcPasteButton.ItemClick += OcbcPasteButtonOnItemClick;
            dbsPasteButton.ItemClick += DbsPasteButtonOnItemClick;
            var dataSource = (BindingList<Expense>)gridControl.DataSource;
            dataSource.ListChanged += HandleDataSourceChange;
            navBarControl.ActiveGroupChanged += NavBarActiveGroupChangedHandler;

        }

        private void NavBarActiveGroupChangedHandler(object sender, NavBarGroupEventArgs e)
        {
            var caption = e.Group.Caption;
            foreach (Control control in splitContainerControl.Panel2.Controls)
            {
                if (control is XtraUserControl || control is GridControl)
                {
                    control.Visible = control.Tag.ToString() == caption;
                }
            }
        }

        private void OcbcPasteButtonOnItemClick(object sender, ItemClickEventArgs e)
        {
            HandlePasteAction(new OcbcConverter());
        }

        private void DbsPasteButtonOnItemClick(object sender, ItemClickEventArgs e)
        {
            HandlePasteAction(new DbsConverter());
        }

        private void HandlePasteAction(IConverter converter)
        {
            var data = Clipboard.GetDataObject();
            // If the data is text, then set the text of the 
            // TextBox to the text in the Clipboard.
            if (data != null && data.GetDataPresent(DataFormats.Text))
            {
                var expenses = converter.Convert(data.GetData(DataFormats.Text).ToString());
                foreach (var expense in expenses)
                {
                    _controller.AddExpense(expense);
                }
            }
        }

        private void NewItemButtonItemClick(object sender, ItemClickEventArgs e)
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

        private void SaveButtonItemClick(object sender, ItemClickEventArgs e)
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