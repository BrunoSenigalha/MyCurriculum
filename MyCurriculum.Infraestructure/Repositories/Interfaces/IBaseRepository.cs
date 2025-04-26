using MyCurriculum.Models;
using System.Linq.Expressions;

namespace MyCurriculum.Infraestructure.Repositories.Interfaces
{
    public interface IBaseRepository<T> 
    {
        Task<IEnumerable<T>> GetAll();

        T? Get(Expression<Func<T, bool>> predicate);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        T Delete(T entity);
    }
}
