using PraejimoKontrolesSistema;
using PraejimoKontrolesSistema.Classes;
using PraejimoKontrolesSistema.Repositories;

namespace TestPraejimoKontrolesSistema.Tests
{
    public class TestDataReader
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDataReader_GetDataFromFile_Report_ListCountGreaterThan0()
        {
            //Arrange
            List<Report> list = new List<Report>();
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