using System;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using DevExpress.XtraEditors;
using DevExpress.Utils.Design;
using DevExpress.Skins;

namespace DXWindowsApplication2 {
    public class BaseControl : XtraUserControl {
        public BaseControl() {
            if (!DesignTimeTools.IsDesignMode)
                LookAndFeel.ActiveLookAndFeel.StyleChanged += ActiveLookAndFeelStyleChanged;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (!DesignTimeTools.IsDesignMode)
                LookAndFeelStyleChanged();
        }
        protected override void Dispose(bool disposing) {
            if (disposing && !DesignTimeTools.IsDesignMode)
                LookAndFeel.ActiveLookAndFeel.StyleChanged -= ActiveLookAndFeelStyleChanged;
            base.Dispose(disposing);
        }
        void ActiveLookAndFeelStyleChanged(object sender, EventArgs e) {
            LookAndFeelStyleChanged();
        }
        protected virtual void LookAndFeelStyleChanged() { }
    }

    public class NavPanePanel : BaseControl {
        NavPaneState _state = NavPaneState.Collapsed;
        public NavPaneState State {
            get { return _state; }
            set {
                _state = value;
                RefreshBackColor();
            }
        }
        protected override void LookAndFeelStyleChanged() {
            base.LookAndFeelStyleChanged();
            RefreshBackColor();
        }

        private void RefreshBackColor() {
            BackColor = new SkinElementInfo(CommonSkins.GetSkin(LookAndFeel)[CommonSkins.SkinTextBorder]).Element.Border.Bottom;
            Padding = new Padding(BorderByState(_state), 1, 1, IsOfficeStyle ? BorderByState(_state) : 1);
        }
        static int BorderByState(NavPaneState state) {
            return state == NavPaneState.Collapsed ? 0 : 1;
        }
        bool IsOfficeStyle {
            get {
                return LookAndFeel.ActiveSkinName.IndexOf("Office", StringComparison.Ordinal) > -1;
            }
        }
    }


}
