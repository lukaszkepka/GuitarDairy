using GuitarDairy.Application.Interfaces;
using GuitarDairy.Application.Services.Interfaces;
using GuitarDairy.Domain.Entities;
using GuitarDairy.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Application.Services
{
    public class MonthSummaryService : IMonthSummaryService
    {
        private readonly IEntryRepository _entryRepository;

        public MonthSummaryService(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<MonthSummary> GetSummaryFor(MonthDate month)
        {
            var dateRange = month.ToDaysRange();
            var entriesInMonth = await _entryRepository.AllBetween(dateRange.From, dateRange.To);

            return MonthSummary.FromEntries(month, entriesInMonth);
        }
    }
}
