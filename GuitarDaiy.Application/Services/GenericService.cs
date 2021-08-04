using GuitarDairy.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarDairy.Application.Services
{
    public class GenericService<T> where T : class
    {
        protected readonly ICRUDRepository<T> _genericRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public GenericService(ICRUDRepository<T> genericRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public virtual void Add(T entity)
        {
            _genericRepository.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public async virtual Task<T> Get(long id)
        {
            return await _genericRepository.Get(id);
        }

        public async virtual Task<IEnumerable<T>> All()
        {
            return await _genericRepository.All();
        }

        public void Update(T entity)
        {
            _genericRepository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _genericRepository.Delete(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
