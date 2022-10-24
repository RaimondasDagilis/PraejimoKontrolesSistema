using PraejimoKontrolesSistema.Classes;

namespace TestPraejimoKontrolesSistema.Tests
{
    internal class TestDataWriter
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCheckFile_CheckingExistingFile_ResultTrue()
        {
            //Arrange
            string fileName = "Test.xml";
            string data = "Test";
            bool fileExist;
            //Act
            using (FileStream testFile = File.Create(fileName)) {}
            fileExist = DataWriter.CheckFile(fileName, data);            
            File.Delete(fileName);
            //Assert
            Assert.IsTrue(fileExist);
        }
        [Test]
        public void TestCheckFile_CheckingNotExistingFile_ResultFalse()
        {
            //Arrange
            string fileName = "Test.xml";
            string data = "Test";
            bool fileExist;
            //Act
            using (FileStream testFile = File.Create(fileName)) { }
            fileExist = DataWriter.CheckFile("Test" + fileName, data);
            File.Delete(fileName);
            File.Delete("Test" + fileName);
            //Assert
            Assert.IsFalse(fileExist);
        }
    }
}
