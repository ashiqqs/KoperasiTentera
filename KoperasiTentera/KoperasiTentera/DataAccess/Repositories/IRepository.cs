using System.Collections.Generic;

namespace KoperasiTentera.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> CreateAsync(TEntity entity);
        Task<TEntity?> UpdateAsync(int id, TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
