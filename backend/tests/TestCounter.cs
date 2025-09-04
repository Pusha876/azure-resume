using Microsoft.Extensions.Logging;
using Xunit;
using Company.Function;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Moq;
using System.Text;

namespace tests
{
    public class TestCounter
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async Task Http_trigger_should_return_known_string()
        {
            // Arrange
            var mockRequest = new Mock<HttpRequestData>();
            var mockResponse = new Mock<HttpResponseData>(HttpStatusCode.OK);
            var stream = new MemoryStream();
            
            mockResponse.SetupGet(r => r.Body).Returns(stream);
            mockResponse.SetupProperty(r => r.StatusCode);
            mockResponse.Setup(r => r.CreateResponse()).Returns(mockResponse.Object);
            mockRequest.Setup(r => r.CreateResponse(It.IsAny<HttpStatusCode>())).Returns(mockResponse.Object);

            var counter = new Counter() { Id = "1", Count = 2 };
            var loggerFactory = new Mock<ILoggerFactory>();
            loggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(logger);

            var function = new GetResumeCounter(loggerFactory.Object);

            // Act
            var result = await function.Run(mockRequest.Object, counter);

            // Assert
            Assert.Equal(3, result.Counter?.Count);
        }
    }
}