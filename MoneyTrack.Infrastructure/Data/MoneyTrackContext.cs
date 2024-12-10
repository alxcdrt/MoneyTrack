using Microsoft.EntityFrameworkCore;
using MoneyTrack.Domain.Data;

namespace MoneyTrack.Infrastructure.Data;

public class MoneyTrackContext(DbContextOptions<MoneyTrackContext> options) : DbContext(options), IStore
{
    #region Methods

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoneyTrackContext).Assembly);
    }

    Task IStore.SaveChangesAsync(CancellationToken cancellationToken) => SaveChangesAsync(cancellationToken);

    Task IStore.AddAsync(object entity, CancellationToken cancellationToken) => AddAsync(entity, cancellationToken).AsTask();

    void IStore.Remove(object entity) => Remove(entity);

    void IStore.Update(object entity) => Update(entity);

    #endregion Methods
}