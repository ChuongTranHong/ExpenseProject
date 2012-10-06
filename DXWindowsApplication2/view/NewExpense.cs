using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DXWindowsApplication2.Controller;
using DXWindowsApplication2.Model;
using DevExpress.XtraEditors;

namespace DXWindowsApplication2.view
{
    public partial class NewExpense : DevExpress.XtraEditors.XtraForm
    {
        private readonly NewExpenseController _controller;

        public NewExpense(IController controller)
        {
            _controller = (NewExpenseController)controller;
            _controller.SetView(this);
            InitializeComponent();
            setEventHandler();
            _controller.OnLoad();
        }

        public void setEventHandler()
        {
            this.submitButton.MouseClick += SubmitButtonClick;
            this.cancelButton.MouseClick += CancelButtonClick;
        }
        private void CancelButtonClick(object sender, MouseEventArgs mouseEventArgs)
        {
            var parent = this.Owner;
            parent.Focus();
            this.Close();
        }
        private void SubmitButtonClick(Object sender, MouseEventArgs mourseEventArgs)
        {
            DateTime time = new DateTime();
            double value=0;
            Boolean isCorrect = true;
            try
            {
                time = (DateTime)dateText.EditValue;
                errorProvider1.Clear();
            }
            catch(Exception)
            {
                errorProvider1.SetError(dateText, "Date must be set");
                isCorrect =false;
            }
            
            string field = fieldDropDown.Text;
            string description = descriptionText.Text;
            try
            {
                value = Convert.ToDouble(valueText.Text);
                errorProvider2.Clear();
            }
            catch(Exception)
            {
                errorProvider2.SetError(valueText,"value must be a number");
                isCorrect =false;
            }
            
            Boolean isExpense = expenseCheck.Checked;
            if(string.IsNullOrEmpty(field))
            {
                errorProvider3.SetError(fieldDropDown,"field need to be filled");
                isCorrect =false;
            }
            else
            {
                errorProvider3.Clear();
            }
            if (!isCorrect) return;
            var expense = new Expense(field,description,value,isExpense,time);
            Form1 parent = (Form1)this.Owner;
            parent.addExpense(expense);
            parent.Focus();
            this.Close();
            
        }
        public ComboBoxEdit FieldDropDown
        {
            get { return fieldDropDown; }
        }
    }
}