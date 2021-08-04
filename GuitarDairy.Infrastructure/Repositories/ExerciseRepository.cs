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
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(GuitarDairyContext dbContext) : base(dbContext)
        {
        }

        public override Task<List<Exercise>> All(bool @readonly = false)
        {
            return @readonly
                ? DbSet.AsNoTracking().Include(x => x.Category).ToListAsync()
                : DbSet.Include(x => x.Category).ToListAsync();
        }

        public override Task<Exercise> Get(long id)
        {
            return DbSet.Include(e => e.Category).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
