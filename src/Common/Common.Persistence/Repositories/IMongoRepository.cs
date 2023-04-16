using Common.Models;
using Common.Persistence.Entities;
using System.Linq.Expressions;

namespace Common.Persistence.Repositories
{
    public interface IMongoRepository<T> where T : MongoEntity
    {
        Task<T> GetAsync(string id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<PageableModel<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, int size = 50, int page = 0);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(string id);
        Task DeleteAsync(T entity);
    }
}
