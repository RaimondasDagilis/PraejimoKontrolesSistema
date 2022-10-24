using PraejimoKontrolesSistema;
using PraejimoKontrolesSistema.Classes;
using PraejimoKontrolesSistema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPraejimoKontrolesSistema.Tests
{
    internal class TestReportGenerator
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGenerateReport_DataIsPassed_ReturnedListCountGreaterThan0()
        {
            //Arrange
            PassingRepository passingRepository = new PassingRepository();
            EmploeeRepository emploeeRepository = new EmploeeRepository();
            ReportGenerator reportGenerator = new ReportGenerator(passingRepository, emploeeRepository);
            //Act            
            List<Report> reportList = reportGenerator.GenerateReport(new DateTime(1, 1, 1, 0, 0, 0), DateTime.Now);
            //Assert
            Assert.Greater(reportList.Count, 0);
        }
    }
}
