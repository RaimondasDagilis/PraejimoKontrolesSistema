using PraejimoKontrolesSistema;
using PraejimoKontrolesSistema.Repositories;

namespace TestPraejimoKontrolesSistema
{
    public class TestRepositories
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestReportRepository_AddReport_ReportListCountPlus1()
        {
            //Arrange
            ReportRepository reportRepository = new ReportRepository();
            int desiredResult = reportRepository.GetReports().Count + 1;
            //Act
            reportRepository.AddReport(1, DateTime.Now, true);
            //Assert
            Assert.AreEqual(desiredResult, reportRepository.GetReports().Count);
        }
        [Test]
        public void TestReportRepository_GetReports_ListCountGreaterThan0()
        {
            //Arrange
            ReportRepository reportRepository = new ReportRepository();
            //Act
            int desiredResult = reportRepository.GetReports().Count;
            //Assert
            Assert.Greater(desiredResult, 0);

        }
        [Test]
        public void TestReportRepository_GetReports_ExistingIdIsPassed_GetsReportWithDesiredId()
        {
            //Arrange
            ReportRepository reportRepository = new ReportRepository();
            //Act
            int id = 1;
            Report report = reportRepository.GetReports(id);
            //Assert
            Assert.AreEqual(id, report.Id);
        }
        [Test]
        public void TestReportRepository_GetReports_NotExistingIdIsPassed_GetsNull()
        {
            //Arrange
            ReportRepository reportRepository = new ReportRepository();
            //Act
            int id = -1;
            Report report = reportRepository.GetReports(id);
            //Assert
            Assert.IsNull(report);
        }
        [Test]
        public void TestPermissionRepository_GetPermitions_ListCountGreaterThan0()
        {
            //Arrange
            PermissionRepository permissionRepository = new PermissionRepository();
            //Act
            int desiredResult = permissionRepository.GetPermitions().Count;
            //Assert
            Assert.Greater(desiredResult, 0);

        }        
        [Test]
        public void TestPermissionRepository_GetPermitions_ExistingIdIsPassed_GetsPermissionWithDesiredId()
        {
            //Arrange
            PermissionRepository permissionRepository = new PermissionRepository();
            //Act
            int id = 3;
            Permition permition = permissionRepository.GetPermitions(id);
            //Assert
            Assert.AreEqual(id, permition.Id);
        }
        [Test]
        public void TestPermissionRepository_GetPermitions_NotExistingIdIsPassed_GetsNull()
        {
            //Arrange
            PermissionRepository permissionRepository = new PermissionRepository();
            //Act
            int id = -1;
            Permition permition = permissionRepository.GetPermitions(id);
            //Assert
            Assert.IsNull(permition);
        }
        [Test]
        public void TestEmploeeRepository_GetEmploees_ListCountGreaterThan0()
        {
            //Arrange
            EmploeeRepository emploeeRepository = new EmploeeRepository();
            //Act
            int desiredResult = emploeeRepository.GetEmploees().Count;
            //Assert
            Assert.Greater(desiredResult, 0);
        }
        [Test]
        public void TestEmploeeRepository_GetEmploees_ExistingIdIsPassed_GetsPermissionWithDesiredId()
        {
            //Arrange
            EmploeeRepository emploeeRepository = new EmploeeRepository();
            //Act
            int id = 3;
            Emploee emploee = emploeeRepository.GetEmploees(id);
            //Assert
            Assert.AreEqual(id, emploee.Id);
        }
        [Test]
        public void TestEmploeeRepository_GetEmploees_NotExistingIdIsPassed_GetsNull()
        {
            //Arrange
            EmploeeRepository emploeeRepository = new EmploeeRepository();
            //Act
            int id = -1;
            Emploee emploee = emploeeRepository.GetEmploees(id);
            //Assert
            Assert.IsNull(emploee);
        }

    }    

}