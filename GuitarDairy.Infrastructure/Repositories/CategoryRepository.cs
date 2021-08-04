using GuitarDairy.Application.Interfaces;
using GuitarDairy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Infrastructure.EF.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GuitarDairyContext dbContext) : base(dbContext)
        {
        }
    }
}
