using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using System.IO;
using DevExpress.XtraScheduler.iCalendar;

//using DevExpress.XtraScheduler.iCalendar; for the import and export appointment

namespace DXWindowsApplication2.view {
    public partial class Calendar : XtraUserControl
    {
        RibbonControl ribbon;
        NavigateCalendar calendarControls;
        RibbonPageCategory appointmentCategory = null;
        RibbonPage lastSelectedPage = null;
        public Calendar() {
            InitializeComponent();

            DatabindScheduler();
            schedulerControl1.Start = new DateTime(2011, 04, 04);
            SubscribeSchedulerEvents();
            UpdateAppointmentCategory();
        }

//        protected override bool SaveCalendarVisible { get { return true; } }

        private void DatabindScheduler() {
            schedulerStorage1.Resources.DataSource = DataHelper.CalendarResources;
            schedulerStorage1.Appointments.DataSource = DataHelper.CalendarAppointments;
        }
        public void SetupCalendarControll(NavigateCalendar navigateCalendar)
        {
            navigateCalendar.InitDateNavigator(schedulerControl1);
           
        }

//        internal override void InitModule(DevExpress.Utils.Menu.IDXMenuManager manager, object data) {
//            base.InitModule(manager, data);
//            schedulerControl1.MenuManager = manager;
//            ribbon = manager as RibbonControl;
//            appointmentCategory = FindAppointmentPage(ribbon);
//
//            if (calendarControls == null) {
//                calendarControls = data as NavigateCalendar;
//                calendarControls.InitDateNavigator(schedulerControl1);
////                this.calendarControls.InitResourcesTree(this.schedulerStorage1);
//                calendarControls.InitBarController(schedulerControl1);
//            }
//        }
        private RibbonPageCategory FindAppointmentPage(RibbonControl ribbonControl) {
            foreach (RibbonPageCategory category in ribbonControl.PageCategories)
                if (category.Tag != null && category.Tag.ToString() == "CalendarTools")
                    return category;
            return null;
        }

        private void SubscribeSchedulerEvents() {
            schedulerStorage1.FilterAppointment += schedulerStorage1_FilterAppointment;
            schedulerStorage1.AppointmentsDeleted += SchedulerStorage1AppointmentsDeleted;
            schedulerStorage1.AppointmentDeleting += SchedulerStorage1AppointmentDeleting;
            schedulerControl1.SelectionChanged += SchedulerControl1SelectionChanged;
        }

        void SchedulerStorage1AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e) {
            HideAppointmentCategory();
        }
//        private void UnsubscribeSchedulerEvents() {
//            schedulerStorage1.FilterAppointment -= schedulerStorage1_FilterAppointment;
//            schedulerControl1.SelectionChanged -= SchedulerControl1SelectionChanged;
//            schedulerStorage1.AppointmentsDeleted -= SchedulerStorage1AppointmentsDeleted;
//            schedulerControl1.SelectionChanged -= SchedulerControl1SelectionChanged;
//        }
        
        void SchedulerControl1SelectionChanged(object sender, EventArgs e) {
            UpdateAppointmentCategory();
        }
        void UpdateAppointmentCategory() {
            if (schedulerControl1.SelectedAppointments.Count > 0)
                ShowAppointmentCategory();
            else
                HideAppointmentCategory();
        }
        private void schedulerStorage1_FilterAppointment(object sender, PersistentObjectCancelEventArgs e) {
//            Appointment apt = (Appointment)e.Object;
//            if (Resource.Empty.Equals(apt.ResourceId))
//                return;
//            List<int> selectedIds = this.calendarControls.GetSelectedResourceIds();
//            var resourceId = Convert.ToInt32(apt.ResourceId);
//            e.Cancel = !selectedIds.Contains(resourceId);
        }
        void SchedulerStorage1AppointmentsDeleted(object sender, PersistentObjectsEventArgs e) {
            HideAppointmentCategory();
        }
        private void SchedulerControl1InitNewAppointment(object sender, AppointmentEventArgs e) {
//            List<int> selectedIds = this.calendarControls.GetSelectedResourceIds();
//            if (selectedIds.Count > 0)
//                e.Appointment.ResourceId = selectedIds[0];
        }



        void ShowAppointmentCategory() {
            if (appointmentCategory == null)
                return;
            if (lastSelectedPage == null)
                lastSelectedPage = ribbon.SelectedPage;
            appointmentCategory.Visible = true;
            ribbon.SelectedPage = GetFirstVisiblePage(appointmentCategory);
        }
        void HideAppointmentCategory() {
            if (appointmentCategory == null)
                return;
            appointmentCategory.Visible = false;
            if (lastSelectedPage != null) {
                ribbon.SelectedPage = lastSelectedPage;
                lastSelectedPage = null;
            }
        }
        RibbonPage GetFirstVisiblePage(RibbonPageCategory ribbonPageCategory) {
            foreach (RibbonPage page in ribbonPageCategory.Pages)
                if (page.Visible)
                    return page;
            return null;
        }

    }
}
