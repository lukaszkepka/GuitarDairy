using GuitarDairy.Application.Interfaces;
using GuitarDairy.Application.Services.Interfaces;
using GuitarDairy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Application.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }
    }
}
