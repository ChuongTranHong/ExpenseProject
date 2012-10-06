namespace DXWindowsApplication2.view
{
    partial class NewExpense
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateText = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.descriptionText = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.valueText = new DevExpress.XtraEditors.TextEdit();
            this.submitButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.expenseCheck = new DevExpress.XtraEditors.CheckEdit();
            this.fieldDropDown = new DevExpress.XtraEditors.ComboBoxEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dateText.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expenseCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldDropDown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Field:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Date:";
            // 
            // dateText
            // 
            this.dateText.EditValue = null;
            this.dateText.Location = new System.Drawing.Point(58, 48);
            this.dateText.Name = "dateText";
            this.dateText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateText.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateText.Size = new System.Drawing.Size(112, 20);
            this.dateText.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 98);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Description:";
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(100, 90);
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(164, 20);
            this.descriptionText.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 146);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(30, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Value:";
            // 
            // valueText
            // 
            this.valueText.Location = new System.Drawing.Point(100, 138);
            this.valueText.Name = "valueText";
            this.valueText.Size = new System.Drawing.Size(164, 20);
            this.valueText.TabIndex = 7;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(262, 176);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Submit";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(355, 176);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            // 
            // expenseCheck
            // 
            this.expenseCheck.EditValue = true;
            this.expenseCheck.Location = new System.Drawing.Point(229, 12);
            this.expenseCheck.Name = "expenseCheck";
            this.expenseCheck.Properties.Caption = "Expense";
            this.expenseCheck.Size = new System.Drawing.Size(75, 19);
            this.expenseCheck.TabIndex = 10;
            // 
            // fieldDropDown
            // 
            this.fieldDropDown.Location = new System.Drawing.Point(58, 10);
            this.fieldDropDown.Name = "fieldDropDown";
            this.fieldDropDown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fieldDropDown.Size = new System.Drawing.Size(112, 20);
            this.fieldDropDown.TabIndex = 11;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // NewExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 212);
            this.Controls.Add(this.fieldDropDown);
            this.Controls.Add(this.expenseCheck);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.valueText);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.descriptionText);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dateText);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "NewExpense";
            this.Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)(this.dateText.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expenseCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldDropDown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateText;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit descriptionText;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit valueText;
        private DevExpress.XtraEditors.SimpleButton submitButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.CheckEdit expenseCheck;
        private DevExpress.XtraEditors.ComboBoxEdit fieldDropDown;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
    }
}