namespace Catalog.API.Interfaces.UoW
{
    public interface ICatalogUoW
    {
        /// <summary>
        /// Instance of BaseRepository for Product Entity
        /// </summary>
        IBaseRepository<Product> ProductBaseRepository { get; }

        /// <summary>
        /// Commit changes asynchronously
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task CommitAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Rollback the changes asynchronously 
        /// </summary>
        /// <returns></returns>
        Task RollbackAsync();
    }
}