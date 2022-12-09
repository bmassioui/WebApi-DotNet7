using Catalog.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.UoW;

public class CatalogUoW : IDisposable, ICatalogUoW
{
    private readonly CatalogDbContext _catalogDbContext;
    private IBaseRepository<Product>? _productBaseRepository;
    private bool disposed = false;

    public IBaseRepository<Product> ProductBaseRepository => _productBaseRepository ??= new BaseRepository<Product>(_catalogDbContext);

    public CatalogUoW(CatalogDbContext catalogDbContext)
    {
        _catalogDbContext = catalogDbContext ?? throw new ArgumentNullException(nameof(catalogDbContext), "Unable to resolve Catalog Db Context");
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _catalogDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RollbackAsync()
    {
        var changedEntries = _catalogDbContext.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged);

        foreach (var entry in changedEntries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Modified:
                case EntityState.Deleted:
                    await entry.ReloadAsync();
                    break;
            }
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed && disposing) _catalogDbContext.Dispose();

        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
