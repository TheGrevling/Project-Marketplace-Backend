namespace Marketplace.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(object id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
        Task<IEnumerable<T>> GetByUserId(string userId, Func<T, string> getUserIdFunc);
    }
}
