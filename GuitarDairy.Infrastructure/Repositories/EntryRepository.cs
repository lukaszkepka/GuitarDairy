using GuitarDairy.Application;
using GuitarDairy.Application.Interfaces;
using GuitarDairy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Infrastructure.EF.Repositories
{
    public class EntryRepository : GenericRepository<Entry>, IEntryRepository
    {
        public EntryRepository(GuitarDairyContext dbContext) : base(dbContext)
        {
        }
    }
}
