using Microsoft.EntityFrameworkCore;

namespace MoneyTrack.Domain.Data;

public interface IStore
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task AddAsync(object entity, CancellationToken cancellationToken = default);
    void Update(object entity);
    void Remove(object entity);
    DbSet<T> Set<T>() where T : class;
}