using ClubManagement.Backbone;
using Microsoft.EntityFrameworkCore;

namespace ClubManagement.Repositories.Interfaces
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly DbContext db;
        protected readonly DbSet<T> DbSet;
        protected IQueryable<T> GetQuery;

        protected BaseRepository(DbContext context)
        {
            db = context;
            DbSet = db.Set<T>();
            GetQuery = DbSet;
        }

        public void Add(T entity) => DbSet.Add(entity);

        public void AddRange(T[] entities) => DbSet.AddRange(entities);

        public void Update(T entity) => DbSet.Update(entity);

        public virtual void Remove(T entity) => DbSet.Remove(entity);

        public virtual void RemoveRange(T[] entities) => DbSet.RemoveRange(entities);

        public async Task<TOther?> GetOtherAsync<TOther>(Guid id) where TOther : Entity =>
            await db.Set<TOther>().FirstOrDefaultAsync(entity => entity.Id == id);

        public async Task<IEnumerable<T>> GetAllAsync() => await GetQuery.ToListAsync();

        public async Task<T?> GetAsync(Guid id) => await GetQuery.FirstOrDefaultAsync(entity => entity.Id == id);

        public async Task<bool> ExistsByIdAsync(Guid id) => await GetQuery.AsNoTracking().AnyAsync(f => f.Id == id);

        public async Task<bool> AnyAsync() => await GetQuery.AsNoTracking().AnyAsync();
    }
}
