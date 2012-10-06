using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DXWindowsApplication2.Controller;
using DXWindowsApplication2.view;
using DevExpress.LookAndFeel;

namespace DXWindowsApplication2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
            var mainController = new MainPageController();
            Form1 mainForm = new Form1(mainController);
            Application.Run(mainForm);
        }
    }
}