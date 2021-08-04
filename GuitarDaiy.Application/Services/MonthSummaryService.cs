using GuitarDairy.Application.Interfaces;
using GuitarDairy.Domain.Entities;
using GuitarDairy.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Application.Services
{
    public class MonthSummaryService
    {
        private readonly IEntryRepository _entryRepository;

        public MonthSummaryService(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<MonthSummary> GetSummaryFor(MonthDate month)
        {
            var dateRange = month.ToDayRange();
            var entriesInMonth = await _entryRepository.AllBetween(dateRange.From, dateRange.To);

            return new MonthSummary(month, entriesInMonth);
        }
    }
}
