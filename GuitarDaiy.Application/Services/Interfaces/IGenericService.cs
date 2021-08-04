using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarDairy.Application.Services.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        void Add(T entity);        
        void Delete(T entity);
        void Update(T entity);
        Task<IEnumerable<T>> All();
        Task<T> Get(long id);
    }
}
