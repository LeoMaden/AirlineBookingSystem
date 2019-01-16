using AirlineBookingLibrary.Helpers;
using Xunit;

namespace AirlineBookingLibrary.Tests.HelpersTests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void NullIfEmpty_ReturnsNullCorrectly()
        {
            // Arrange
            object expected = null;

            // Act
            string str = "";
            string actual = str.NullIfEmpty();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("hello world")]
        [InlineData("test string")]
        [InlineData("s")]
        public void NullIfEmpty_ReturnsStringCorrectly(string str)
        {
            string expected = str;

            string actual = str.NullIfEmpty();

            Assert.Equal(expected, actual);
        }
    }
}
