using FluentAssertions;
using GuitarDairy.Domain.ValueObjects;
using System;
using Xunit;

namespace GuitarDairy.UnitTests.Domain
{
    public class MonthDateUnitTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(13)]
        public void ShouldThrowArgumentOutOfRangeException_WhenMonthOutOfRange(int month)
        {
            // Arrange
            // Act
            Action action = () => new MonthDate(month, 2020);

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(56544)]
        public void ShouldThrowArgumentOutOfRangeException_WhenYearOutOfRange(int year)
        {
            // Arrange
            // Act
            Action action = () => new MonthDate(1, year);

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(1, 2020)]
        [InlineData(1, 1)]
        public void CreatedProperly_ForStandardArguments(int month, int year)
        {
            // Arrange
            // Act
            var monthDate = new MonthDate(month, year);

            // Assert
            Assert.Equal(month, monthDate.Month);
            Assert.Equal(year, monthDate.Year);
        }

        [Theory]
        [InlineData(31, 12, 2020)]
        [InlineData(1, 1, 1)]
        public void CreatedProperly_FromDateTime(int day, int month, int year)
        {
            // Arrange
            var dateTime = new DateTime(year, month, day);

            // Act
            MonthDate monthDate = dateTime;

            // Assert
            Assert.Equal(month, monthDate.Month);
            Assert.Equal(year, monthDate.Year);
        }

        [Theory]
        [InlineData(12, 2020)]
        [InlineData(1, 1)]
        public void ConvertedProperly_ToDateTime(int month, int year)
        {
            // Arrange
            var monthDate = new MonthDate(month, year);

            // Act
            DateTime dateTime = monthDate;

            // Assert
            Assert.Equal(1, dateTime.Day);
            Assert.Equal(month, dateTime.Month);
            Assert.Equal(year, dateTime.Year);
        }
    }
}
