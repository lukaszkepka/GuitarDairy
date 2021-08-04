using GuitarDairy.Application.Interfaces;
using GuitarDairy.Application.Services.Interfaces;
using GuitarDairy.Domain.Entities;
using System.Threading.Tasks;

namespace GuitarDairy.Application.Services
{
    public class ExerciseService : GenericService<Exercise>, IExerciseService
    {
        public ExerciseService(IExerciseRepository genericRepository, IUnitOfWork unitOfWork)
            : base(genericRepository, unitOfWork)
        {
        }
    }
}
