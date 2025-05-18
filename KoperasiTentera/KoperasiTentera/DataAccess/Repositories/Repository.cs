using Microsoft.EntityFrameworkCore;

namespace KoperasiTentera.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        public readonly SqlDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(SqlDbContext context, DbSet<TEntity> dbSet) {
            _dbContext = context;
            _dbSet = dbSet;
        }

        public async Task<TEntity?> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            bool isCreated = await _dbContext.SaveChangesAsync() > 0;
            return isCreated ? entity : null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) throw new Exception($"{nameof(TEntity)} not found");

            _dbSet.Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<TEntity?> UpdateAsync(int id, TEntity entity)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing == null) throw new Exception($"{nameof(TEntity)} not found");

            _dbContext.Entry(existing).CurrentValues.SetValues(entity);
            bool isUpdated = await _dbContext.SaveChangesAsync() > 0;
            return isUpdated ? entity : null;
        }
    }
}
