using System;
using System.Windows.Forms;
using DXWindowsApplication2.Controller;
using DXWindowsApplication2.Model;
using DevExpress.XtraEditors;

namespace DXWindowsApplication2.view
{
    public partial class NewExpenseView : XtraForm
    {
        private readonly NewExpenseController _controller;
        private readonly Expense _currentEditExpense;
        public NewExpenseView(IController controller)
        {
            _controller = (NewExpenseController)controller;
            _controller.SetView(this);
            InitializeComponent();
            setEventHandler();
            _controller.OnLoad();
        }

        public NewExpenseView(Expense row):this(new NewExpenseController())
        {
            _currentEditExpense = row;
            FieldDropDown.Text = row.Field;
            descriptionText.Text = row.Description;
            valueText.Text = row.Value.ToString();
            expenseCheck.Checked =row.IsExpense;
            dateText.EditValue = row.Time;
        }

        private void setEventHandler()
        {
            submitButton.MouseClick += SubmitButtonClick;
            cancelButton.MouseClick += CancelButtonClick;
        }
        private void CancelButtonClick(object sender, MouseEventArgs mouseEventArgs)
        {
            var parent = Owner;
            parent.Focus();
            Close();
        }

        private void SubmitButtonClick(Object sender, MouseEventArgs mourseEventArgs)
        {
            if (!ValidateBeforeSubmit()) return;

            var time = (DateTime) dateText.EditValue;
            var value = Convert.ToDouble(valueText.Text);
            var isExpense = expenseCheck.Checked;
            var description = descriptionText.Text;
            var field = FieldDropDown.Text;
            var parent = (MainPageView)this.Owner;
            if (_currentEditExpense == null) 
                parent.AddExpense(new Expense(field, description, value, isExpense, time));
            else
            {
                _currentEditExpense.Field = field;
                _currentEditExpense.Description = description;
                _currentEditExpense.IsExpense = isExpense;
                _currentEditExpense.Time = time;
                _currentEditExpense.Value = value;

            }
            parent.Focus();
            Close();
            
        }
        
        private Boolean ValidateBeforeSubmit()
        {
            var isCorrect = true;
            try
            {
                var time = (DateTime)dateText.EditValue;
                errorProvider1.Clear();
            }
            catch (Exception)
            {
                errorProvider1.SetError(dateText, "Date must be set");
                isCorrect = false;
            }

            try
            {
                Convert.ToDouble(valueText.Text);
                errorProvider2.Clear();
            }
            catch (Exception)
            {
                errorProvider2.SetError(valueText, "value must be a number");
                isCorrect = false;
            }

            if (string.IsNullOrEmpty(FieldDropDown.Text))
            {
                errorProvider3.SetError(FieldDropDown, "field need to be filled");
                isCorrect = false;
            }
            else
            {
                errorProvider3.Clear();
            }

            return isCorrect;
        }

        public ComboBoxEdit FieldDropDown { get; private set; }
    }
}