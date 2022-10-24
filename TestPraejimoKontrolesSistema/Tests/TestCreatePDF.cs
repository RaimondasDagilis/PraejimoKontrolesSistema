using PraejimoKontrolesSistema.Classes;

namespace TestPraejimoKontrolesSistema.Tests
{
    public class TestCreatePDF
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreatePDFFromHtml_ExampleDataIsPassed_FileMustBeCreated()
        {
            //Arrange
            string fileName = "Test.pdf";
            string html = "<h1>Test file<h1>";
            bool fileExist = false;
            //Act
            CreatePDF.CreatePdfFromHtml(html, fileName);
            fileExist = File.Exists(fileName);
            File.Delete(fileName);
            //Assert
            Assert.IsTrue(fileExist);
        }
    }
}