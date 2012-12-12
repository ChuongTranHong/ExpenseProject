using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using DevExpress.Utils;
using System.Windows.Forms;
using System.IO;
//using System.ServiceModel.Syndication;

namespace DXWindowsApplication2
{
   
    public static class DataHelper
    {

        static DataTable _calendarResourcesTable;
        static DataTable _calendarAppointmentsTable;


        internal static DataTable CalendarResources
        {
            get
            {
                if (_calendarResourcesTable == null)
                {
                    const string table = "Resources";
                    _calendarResourcesTable = CreateDataTable(table);
                }
                return _calendarResourcesTable;
            }
        }
        internal static DataTable CalendarAppointments
        {
            get
            {
                if (_calendarAppointmentsTable == null)
                {
                    const string table = "Appointments";
                    _calendarAppointmentsTable = CreateDataTable(table);
                }
                return _calendarAppointmentsTable;
            }
        }

        private static DataTable CreateDataTable(string table)
        {
            var dataSet = new DataSet();
            var assembly = Assembly.GetExecutingAssembly();
            dataSet.ReadXml(new StreamReader(assembly.GetManifestResourceStream("DXWindowsApplication2.Resources.Mail.xml")));
            return dataSet.Tables[table];
        }
    }
    
        
  
    
}
