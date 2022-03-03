using ClubManagement.Backbone;

namespace ClubManagement.TestApp
{
    public interface IManagerService<TEntity>
        where TEntity : Entity
    {
        Task<TEntity?> CreateAsync();
        Task<IEnumerable<TEntity>> ReadAsync();
        Task<TEntity?> UpdateAsync();
        Task DeleteAsync();
        int GetChoiceFromData(IEnumerable<TEntity> items);
        Task WriteEntityToConsoleAsync(TEntity entity, string? prefix = null);
    }
}
