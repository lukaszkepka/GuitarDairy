using FluentAssertions;
using GuitarDairy.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GuitarDairy.UnitTests.Domain
{
    public class DayDateUnitTests
    {
        [Theory]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(32, 1)]
        [InlineData(31, 4)]
        [InlineData(29, 2, 2005)]
        [InlineData(30, 2, 2004)]
        public void ShouldThrowArgumentOutOfRangeException_WhenDayOutOfRange(int day, int month, int year=2020)
        {
            // Arrange
            // Act
            Action action = () => new DayDate(day, month, year);

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(31, 1)]
        [InlineData(28, 2, 2003)]
        [InlineData(29, 2, 2004)]
        [InlineData(31, 7)]
        [InlineData(30, 4)]
        public void CreatedProperly_ForStandardArguments(int day, int month, int year = 2020)
        {
            // Arrange
            // Act
            var dayDate = new DayDate(day, month, year);

            // Assert
            Assert.Equal(day, dayDate.Day);
            Assert.Equal(month, dayDate.Month);
            Assert.Equal(year, dayDate.Year);
        }
    }
}
