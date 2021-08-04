using FluentAssertions;
using GuitarDairy.Application.Interfaces;
using GuitarDairy.Application.Services;
using GuitarDairy.Domain.ValueObjects;
using GuitarDairy.UnitTests.DataGeneration;
using Moq;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GuitarDairy.UnitTests.Application
{
    public class MonthSummaryServiceTests
    {
        private readonly Mock<IEntryRepository> _entryRepositoryMock;
        private readonly MonthSummaryService _service;

        public MonthSummaryServiceTests()
        {
            _entryRepositoryMock = new();
            _service = new MonthSummaryService(_entryRepositoryMock.Object);
        }

        [Fact]
        public async Task IsEntryRepositoryCalledWithProperRange()
        {
            // Arrange
            var date = new DateTime(2020, 4, 10);

            var exercise = ExerciseDataGenerator.GenerateFromName("E1");
            var entries = EntriesDataGenerator.Generate(exercise, new[]
            {
                Tuple.Create(date, 10),
            }).ToList();

            _entryRepositoryMock
                .Setup(x => x.AllBetween(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(Task.FromResult(entries));

            // Act
            var summary = await _service.GetSummaryFor(date);

            // Assert
            _entryRepositoryMock
                .Verify(x => x
                    .AllBetween(It.Is<DateTime>(x => x == new DateTime(2020, 4, 1)),
                                It.Is<DateTime>(x => x == new DateTime(2020, 4, 30))), Times.Once);

            summary.Entries.Should().HaveCount(entries.Count);
        }
    }
}
