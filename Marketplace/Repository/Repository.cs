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

        public Task<IEnumerable<T>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete(object id)
        {
            throw new NotImplementedException();
        }

    }
}
