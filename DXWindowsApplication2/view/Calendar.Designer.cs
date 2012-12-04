namespace DXWindowsApplication2.view {
    partial class Calendar {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeScaleMonth timeScaleMonth1 = new DevExpress.XtraScheduler.TimeScaleMonth();
            DevExpress.XtraScheduler.TimeScaleWeek timeScaleWeek1 = new DevExpress.XtraScheduler.TimeScaleWeek();
            DevExpress.XtraScheduler.TimeScaleDay timeScaleDay1 = new DevExpress.XtraScheduler.TimeScaleDay();
            DevExpress.XtraScheduler.TimeScaleHour timeScaleHour1 = new DevExpress.XtraScheduler.TimeScaleHour();
            DevExpress.XtraScheduler.TimeScaleFixedInterval timeScaleFixedInterval1 = new DevExpress.XtraScheduler.TimeScaleFixedInterval();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ContactInfo", "ContactInfo", DevExpress.XtraScheduler.FieldValueType.String));
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "EndDate";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceID";
            this.schedulerStorage1.Appointments.Mappings.Start = "StartDate";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.Type = "EventType";
            this.schedulerStorage1.Resources.Mappings.Caption = "Name";
            this.schedulerStorage1.Resources.Mappings.Id = "ID";
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(6, 6);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(871, 438);
            this.schedulerControl1.Start = new System.DateTime(2011, 12, 25, 0, 0, 0, 0);
            this.schedulerControl1.Storage = this.schedulerStorage1;
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.ShowWorkTimeOnly = true;
            timeRuler1.TimeZone.DaylightBias = System.TimeSpan.Parse("-01:00:00");
            timeRuler1.TimeZone.DaylightZoneName = "Malay Peninsula Summer Time";
            timeRuler1.TimeZone.DisplayName = "(UTC+08:00) Kuala Lumpur, Singapore";
            timeRuler1.TimeZone.StandardZoneName = "Malay Peninsula Standard Time";
            timeRuler1.TimeZone.UtcOffset = System.TimeSpan.Parse("08:00:00");
            timeRuler1.UseClientTimeZone = false;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.GanttView.Enabled = false;
            timeScaleMonth1.Enabled = false;
            timeScaleMonth1.Width = 100;
            timeScaleWeek1.Width = 100;
            timeScaleDay1.Width = 100;
            timeScaleHour1.Enabled = false;
            timeScaleHour1.Width = 100;
            timeScaleFixedInterval1.Enabled = false;
            timeScaleFixedInterval1.Value = System.TimeSpan.Parse("00:30:00");
            timeScaleFixedInterval1.Width = 100;
            this.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleMonth1);
            this.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleWeek1);
            this.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleDay1);
            this.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleHour1);
            this.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleFixedInterval1);
            this.schedulerControl1.Views.WorkWeekView.ShowFullWeek = true;
            this.schedulerControl1.Views.WorkWeekView.ShowWorkTimeOnly = true;
            timeRuler2.TimeZone.DaylightBias = System.TimeSpan.Parse("-01:00:00");
            timeRuler2.TimeZone.DaylightZoneName = "Malay Peninsula Summer Time";
            timeRuler2.TimeZone.DisplayName = "(UTC+08:00) Kuala Lumpur, Singapore";
            timeRuler2.TimeZone.StandardZoneName = "Malay Peninsula Standard Time";
            timeRuler2.TimeZone.UtcOffset = System.TimeSpan.Parse("08:00:00");
            timeRuler2.UseClientTimeZone = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.InitNewAppointment += new DevExpress.XtraScheduler.AppointmentEventHandler(this.SchedulerControl1InitNewAppointment);
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.schedulerControl1);
            this.Name = "Calendar";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(883, 450);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
    }
}
