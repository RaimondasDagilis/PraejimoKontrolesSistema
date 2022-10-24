using PraejimoKontrolesSistema.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPraejimoKontrolesSistema.Tests
{
    internal class TestValidation
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestValidateInteger_IntegerStringIsPassed_ReturnsDesiredInteger()
        {
            //Arrange
            string test = "2";
            int result;
            //Act
            result = Validation.ValidateInteger(test);            
            //Assert
            Assert.AreEqual(result, int.Parse(test));
        }
        [Test]
        public void TestValidateInteger_IntegerStringWithErrorIsPassed_Returns0()
        {
            //Arrange
            string test = "2A";
            int result;
            //Act
            result = Validation.ValidateInteger(test);
            //Assert
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void TestValidateDateOnly_DateStringIsPassed_ReturnsGeneratedDate()
        {
            //Arrange
            string test = "2022 10 13";
            DateOnly result;
            //Act
            result = Validation.ValidateDateOnly(test);
            //Assert
            Assert.AreEqual(result, new DateOnly(2022, 10, 13));
        }
        [Test]
        public void TestValidateDateOnly_DateStringWithErrorsIsPassed_ReturnsDate_1_1_1()
        {
            //Arrange
            string test = "Some date";
            DateOnly result;
            //Act
            result = Validation.ValidateDateOnly(test);
            //Assert
            Assert.AreEqual(result, new DateOnly(1, 1, 1));
        }
        [Test]
        public void TestValidateDateTime_DateStringIsPassed_ReturnsGeneratedDate()
        {
            //Arrange
            string test = "2022 10 13";
            DateTime result;
            //Act
            result = Validation.ValidateDateTime(test);
            //Assert
            Assert.AreEqual(result, new DateTime(2022, 10, 13));
        }
        [Test]
        public void TestValidateDateTime_DateStringWithErrorsIsPassed_ReturnsDate_1_1_1_0_0_0()
        {
            //Arrange
            string test = "Some date";
            DateTime result;
            //Act
            result = Validation.ValidateDateTime(test);
            //Assert
            Assert.AreEqual(result, new DateTime(1, 1, 1, 0, 0, 0));
        }
    }
}
