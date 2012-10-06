using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DXWindowsApplication2.Controller;
namespace ClassLibrary1.Controller
{
    [TestFixture]
    class ExcelControllerTest
    {
        private ExcelController _excelController;

        [SetUp]
        public void Setup()
        {
            _excelController = new ExcelController();
        }

        [Test]
        public void testReadFile()
        {
            _excelController.readExcel("C:\\projectTemp\\Blk 179.xlsx");
        }
    }
}
