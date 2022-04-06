using ClubManagement.Backbone;

namespace ClubManagement.Repositories.Interfaces
{
    public interface IBaseRepository<T>
        where T : Entity
    {
        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        Task<T?> GetAsync(Guid id);

        Task<TOther?> GetOtherAsync<TOther>(Guid id) where TOther : Entity;

        Task<IEnumerable<T>> GetAllAsync();

        Task<bool> ExistsByIdAsync(Guid id);

        Task<bool> AnyAsync();
        Task SaveContextChanges();

    }
}
