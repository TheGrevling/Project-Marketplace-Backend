using Marketplace.Data;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _table = null;

        public Repository(DataContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> Insert(T entity)
        {
            _table.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _table.Update(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(object id)
        {
            T entity = await _table.FindAsync(id);
            _table.Update(entity).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetByUserId(string userId, Func<T, string> getUserIdFunc)
        {
            // Materialize the query first using ToListAsync()
            var entities = await _table.ToListAsync();

            // Filter the entities based on the user ID using LINQ to Objects
            return entities.Where(x => getUserIdFunc(x) == userId).ToList();
        }

    }
}
