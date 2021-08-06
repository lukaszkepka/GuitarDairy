using GuitarDairy.Domain.Entities;
using GuitarDairy.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Application.Services.Interfaces
{
    public interface IMonthSummaryService
    {
        Task<MonthSummary> GetSummaryFor(MonthDate month);
    }
}
