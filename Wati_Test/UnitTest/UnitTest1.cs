using Microsoft.Extensions.Logging;
using Wati.Controllers;

namespace UnitTest
{
    public class Tests
    {
        WeatherForecastController cont;

        [SetUp]
        public void Setup()
        {
            var mockLogger = new Moq.Mock<ILogger<WeatherForecastController>>();

            cont = new WeatherForecastController(mockLogger.Object);
        }

        [Test]
        [TestCase(1, 1, ExpectedResult = )]
        public int Test1(int n1, int n2)
        {

            var result = cont.AddCode(n1, n2);


            Assert.Pass();
        }
    }
}