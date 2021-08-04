using GuitarDairy.Application.Interfaces;
using GuitarDairy.Application.Services;
using GuitarDairy.Application.Services.Interfaces;
using GuitarDairy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarDairy.Application.Services
{
    public class EntryService : GenericService<Entry>, IEntryService
    {
        public EntryService(IEntryRepository genericRepository, IUnitOfWork unitOfWork) 
            : base(genericRepository, unitOfWork)
        {
        }
    }
}
