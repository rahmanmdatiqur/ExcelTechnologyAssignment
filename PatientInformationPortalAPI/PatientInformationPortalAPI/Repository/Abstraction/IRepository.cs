namespace PatientInformationPortalAPI.Repository.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Queryable();
        Task<List<TEntity>> Get();
        Task<TEntity> GetById(int id);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(int id);
    }
}
