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
    public class MonthSummaryUnitTests
    {
        [Fact]
        public void PerDaySummariesAreCreatedForEachMonthDay_WhenEntryListIsEmpty()
        {
            // Arrange
            MonthDate monthDate = new(1, 2020);
            var entries = Enumerable.Empty<Entry>();

            // Act
            var summary = MonthSummary.FromEntries(monthDate, entries);

            // Assert
            Assert.Equal(DateTime.DaysInMonth(monthDate.Year, monthDate.Month), summary.PerDaySummaries.Count);
        }

        [Fact]
        public void TimeSpentPerDayComputedProperly_WhenCreatedFromEntries()
        {
            int exercisesCount = 2;
            int itemsCount = 3;

            // Arrange
            DayDate dayDate = new(1, 1, 2020);
            var entries = EntryDataGenerator.New()
                .SetupExerciseCount(exercisesCount)
                .SetupDuration(TimeSpan.FromMinutes(1))
                .SetupItemsCount(dayDate, itemsCount)
                .SetupItemsCount(dayDate.NextDay(), itemsCount)
                .Generate();

            // Act
            var summary = MonthSummary.FromEntries(dayDate, entries);
            var perDaySummaries = summary.PerDaySummaries;

            // Assert
            Assert.All(perDaySummaries.Take(2), x => Assert.Equal(TimeSpan.FromMinutes(itemsCount * exercisesCount), x.TotalTimeSpent));
            Assert.All(perDaySummaries.Skip(2), x => Assert.Equal(TimeSpan.FromMinutes(0), x.TotalTimeSpent));
        }

        [Fact]
        public void PerDaySummariesAreOrdered_WhenCreatedFromEntries()
        {
            int exercisesCount = 2;
            int itemsCount = 3;

            // Arrange
            DayDate dayDate = new(1, 1, 2020);
            var entries = EntryDataGenerator.New()
                .SetupExerciseCount(exercisesCount)
                .SetupDuration(TimeSpan.FromMinutes(1))
                .SetupItemsCount(dayDate, itemsCount)
                .SetupItemsCount(dayDate.NextDay(), itemsCount)
                .Generate();

            // Act
            var summary = MonthSummary.FromEntries(dayDate, entries);

            // Assert
            summary.PerDaySummaries.Should().BeInAscendingOrder(x => x.Date);
        }
    }
}
