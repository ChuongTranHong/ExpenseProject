using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraNavBar;
using DevExpress.XtraScheduler.UI;

namespace DXWindowsApplication2.view {
    public partial class NavigateCalendar : NavPanePanel {
        SchedulerControl _schedulerControl;
        SchedulerBarController _barController;
        
        public NavigateCalendar() {
            InitializeComponent();
        }
        public void InitDateNavigator(SchedulerControl schedulerControl) {
            _schedulerControl = schedulerControl;
            dateNavigator1.SchedulerControl = schedulerControl;
        }
//        public void InitBarController(SchedulerControl scheduler) {
//            _barController.Control = scheduler;
//        }        

//        public void SetBarController(SchedulerBarController barController) {
//            this._barController = barController;
//        }
    }
}
