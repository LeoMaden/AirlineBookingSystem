using AirlineBookingLibrary.Helpers;
using Xunit;

namespace AirlineBookingLibrary.Tests.HelpersTests
{
    public class StringExtensionsTests
    {
        // Tests whether the NullIfEmpty method will return null
        // when given an empty string.
        [Fact]
        public void NullIfEmpty_ReturnsNullCorrectly()
        {
            object expected = null;
            
            string str = "";
            string actual = str.NullIfEmpty();
            
            Assert.Equal(expected, actual);
        }

        // Tests whether the NullIfEmpty method will return the
        // string value when the string is not null.
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
