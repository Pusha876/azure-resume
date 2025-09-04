using Microsoft.Extensions.Logging;
using Xunit;
using Company.Function.Models;

namespace tests
{
    public class TestCounter
    {
        [Fact]
        public void Counter_should_increment_count()
        {
            // Arrange
            var counter = new Counter { Id = "1", Count = 2 };
            
            // Act
            counter.Count += 1;
            
            // Assert
            Assert.Equal(3, counter.Count);
            Assert.Equal("1", counter.Id);
        }

        [Fact]
        public void Counter_should_initialize_with_default_values()
        {
            // Arrange & Act
            var counter = new Counter();
            
            // Assert
            Assert.Equal(string.Empty, counter.Id);
            Assert.Equal(0, counter.Count);
        }

        [Fact]
        public void MultipleOutputBinding_should_hold_counter_and_response()
        {
            // Arrange
            var counter = new Counter { Id = "1", Count = 5 };
            var binding = new MultipleOutputBinding
            {
                CosmosOutput = counter
            };
            
            // Act & Assert
            Assert.NotNull(binding.CosmosOutput);
            Assert.Equal(5, binding.CosmosOutput.Count);
            Assert.Equal("1", binding.CosmosOutput.Id);
        }
    }
}