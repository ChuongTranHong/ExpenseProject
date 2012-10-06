using System.ComponentModel;
using DXWindowsApplication2.Controller;
using DXWindowsApplication2.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;

namespace DXWindowsApplication2.view
{
    public partial class Form1 : XtraForm
    {
        private MainPageController _controller;

        public Form1(IController controller)
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
            this.iNew.ItemClick += this.NewItemClick;
        }
        private void NewItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm newForm = new NewExpense(new NewExpenseController());
            newForm.Owner = this;
            newForm.Show();
            
        }
        public void addExpense(Expense expense)
        {
            _controller.addExpense(expense);
        }



    }
}