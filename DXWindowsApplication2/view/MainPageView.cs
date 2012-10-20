using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DXWindowsApplication2.Controller;
using DXWindowsApplication2.Model;
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
            RegisterListener();
            _controller.OnLoad();

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
            iNew.ItemClick += NewItemClick;
            gridControl.EmbeddedNavigator.ButtonClick += GridControlClick;
        }

        private void NewItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm newForm = new NewExpenseView(new NewExpenseController());
            newForm.Owner = this;
            newForm.Show();
        }

        public void AddExpense(Expense expense)
        {
            _controller.AddExpense(expense);
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

    }
}