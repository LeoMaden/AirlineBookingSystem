using AirlineBookingLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirlineBookingLibrary.Tests
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
    }
}
