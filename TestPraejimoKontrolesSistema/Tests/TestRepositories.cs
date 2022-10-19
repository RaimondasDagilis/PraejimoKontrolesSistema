using PraejimoKontrolesSistema;
using PraejimoKontrolesSistema.Repositories;

namespace TestPraejimoKontrolesSistema.Tests
{
    public class TestRepositories
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPassingRepository_AddPassing_PassingListCountPlus1()
        {
            //Arrange
            PassingRepository passingRepository = new PassingRepository();
            int desiredResult = passingRepository.GetPassings().Count + 1;
            //Act
            passingRepository.AddPassing(1, DateTime.Now, true);
            //Assert
            Assert.AreEqual(desiredResult, passingRepository.GetPassings().Count);
        }
        [Test]
        public void TestPassingRepository_GetPassings_ListCountGreaterThan0()
        {
            //Arrange
            PassingRepository passingRepository = new PassingRepository();
            //Act
            int desiredResult = passingRepository.GetPassings().Count;
            //Assert
            Assert.Greater(desiredResult, 0);

        }
        [Test]
        public void TestPassingRepository_GetPassings_ExistingIdIsPassed_GetsPassingWithDesiredId()
        {
            //Arrange
            PassingRepository passingRepository = new PassingRepository();
            //Act
            int id = 1;
            Passing passing = passingRepository.GetPassings(id);
            //Assert
            Assert.AreEqual(id, passing.Id);
        }
        [Test]
        public void TestPassingRepository_GetPassings_NotExistingIdIsPassed_GetsNull()
        {
            //Arrange
            PassingRepository passingRepository = new PassingRepository();
            //Act
            int id = -1;
            Passing passing = passingRepository.GetPassings(id);
            //Assert
            Assert.IsNull(passing);
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