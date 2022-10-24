using PraejimoKontrolesSistema;
using PraejimoKontrolesSistema.Classes;

namespace TestPraejimoKontrolesSistema.Tests
{
    internal class TestDataReader
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDataReader_GetDataFromFile_Report_ListCountGreaterThan0()
        {
            //Arrange
            List<Passing> list = new List<Passing>();
            //Act
            DataReader.GetDataFromFile(list);
            //Assert
            Assert.Greater(list.Count, 0);
        }
        [Test]
        public void TestDataReader_GetDataFromFile_Emploee_ListCountGreaterThan0()
        {
            //Arrange
            List<Emploee> list = new List<Emploee>();
            //Act
            DataReader.GetDataFromFile(list);
            //Assert
            Assert.Greater(list.Count, 0);
        }
        [Test]
        public void TestDataReader_GetDataFromFile_Permition_ListCountGreaterThan0()
        {
            //Arrange
            List<Permition> list = new List<Permition>();
            //Act
            DataReader.GetDataFromFile(list);
            //Assert
            Assert.Greater(list.Count, 0);
        }
    }
}