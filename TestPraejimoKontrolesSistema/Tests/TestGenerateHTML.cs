using PraejimoKontrolesSistema;
using PraejimoKontrolesSistema.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPraejimoKontrolesSistema.Tests
{
    internal class TestGenerateHTML
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateHML_ListIsPassed_ReturnedStringIsLongerThan0()
        {
            //Arrange
            string result;
            List<Report> testList = new List<Report>();
            //Act
            result = GenerateHTML.CreateHtml(testList, new DateTime(1, 1, 1), new DateTime(1, 1, 1));
            //Assert
            Assert.Greater(result.Length, 0);
        }
    }
}
