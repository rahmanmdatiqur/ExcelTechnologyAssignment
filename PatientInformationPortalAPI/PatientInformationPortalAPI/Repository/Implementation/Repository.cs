using PatientInformationPortalAPI.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace PatientInformationPortalAPI.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        
        private DbSet<TEntity> _table;
        public Repository(PatientDbContext context)
        {
            _table = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
           await _table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        public void Delete(int id)
        {
            var deleteEntity = _table.Find(id);
            _table.Remove(deleteEntity);
        }

        public async Task<List<TEntity>> Get()
        {
            return await _table.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _table.FindAsync(id);
        }

        public virtual IQueryable<TEntity> Queryable()
        {
            return _table;
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }
    }
}
