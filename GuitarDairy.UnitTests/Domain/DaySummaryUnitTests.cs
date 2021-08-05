using FluentAssertions;
using GuitarDairy.Domain.Entities;
using GuitarDairy.Domain.ValueObjects;
using GuitarDairy.UnitTests.DataGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GuitarDairy.UnitTests.Domain
{
    public class DaySummaryUnitTests
    {
        private readonly DayDate _defaultDate = new(1, 1, 2020);

        [Fact]
        public void SummaryShouldBeEmpty_WhenCreatedFromEmptyEntryList()
        {
            // Arrange
            var entries = Enumerable.Empty<Entry>();

            // Act
            var summary = DaySummary.FromEntries(_defaultDate, entries);

            // Assert
            summary.TotalTimeSpent.Should().Be(TimeSpan.FromSeconds(0));
            summary.Date.Should().Equals(_defaultDate);
            summary.ExerciseSummaries.Should().BeEmpty();
        }

        [Fact]
        public void ArgumentExceptionIsThrown_WhenEntriesOutOfAllowedRange()
        {
            // Arrange
            var dateTime = (DateTime)_defaultDate;
            var entries = EntryDataGenerator.New()
                .SetupExerciseCount(1)
                .SetupItemsCount(dateTime, 2)
                .SetupItemsCount(dateTime.AddDays(1), 2)
                .Generate();

            // Act
            Action createSummary = () => DaySummary.FromEntries(dateTime, entries);

            // Assert
            createSummary.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TotalTimeSpentComputedCorrectly_WhenMultipleExercises()
        {
            // Arrange
            var exerciseCount = 2;
            var itemsCount = 10;

            var entries = EntryDataGenerator.New()
                .SetupExerciseCount(exerciseCount)
                .SetupDuration(TimeSpan.FromMinutes(1))
                .SetupItemsCount(_defaultDate, itemsCount)
                .Generate();

            // Act
            var summary = DaySummary.FromEntries(_defaultDate, entries);

            // Assert
            summary.TotalTimeSpent.Should().Be(TimeSpan.FromMinutes(itemsCount * exerciseCount));
        }

        [Fact]
        public void ExerciseSummariesHaveProperTimeSpent_WhenMultipleExercises()
        {
            int exercisesCount = 2;
            int itemsCount = 3;

            // Arrange
            var entries = EntryDataGenerator.New()
                .SetupExerciseCount(exercisesCount)
                .SetupDuration(TimeSpan.FromMinutes(1))
                .SetupItemsCount(_defaultDate, itemsCount)
                .Generate();

            // Act
            var summary = DaySummary.FromEntries(_defaultDate, entries);
            var exerciseSummaries = summary.ExerciseSummaries;

            // Assert
            Assert.Equal(exercisesCount, exerciseSummaries.Count());
            Assert.All(exerciseSummaries, x => Assert.Equal(x.TimeSpent, TimeSpan.FromMinutes(itemsCount)));
        }
    }
}
