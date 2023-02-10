using Common.Models;
using Common.Persistence.Entities;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Common.Persistence.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : Entity
    {
        private readonly IMongoCollection<T> _collection;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(x => x.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task DeleteAsync(T entity)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(x => x.Id, entity.Id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _collection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<PageableModel<T>> GetAllAsync(Expression<Func<T, bool>> filter, int size = 50, int page = 0)
        {
            var list = await _collection.Find(filter).ToListAsync();
            return new PageableModel<T>
            {
                Data = list,
                Page = page,
                Size = size,
                TotalCount= list.Count,
                TotalPages = list.Count / size,
                IsNext = page < list.Count / size,
                IsPrevious = page > list.Count / size
            };
        }

        public async Task<T> GetAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(x => x.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            FilterDefinition<T> filter = filterBuilder.Eq(x => x.Id, entity.Id);

            await _collection.ReplaceOneAsync(filter, entity);

            return entity;
        }
    }
}
