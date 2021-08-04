using GuitarDairy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Application.Interfaces
{
    public interface IExerciseRepository : ICRUDRepository<Exercise>
    {
    }
}
