using System.Linq.Expressions;

namespace Catalog.API.Interfaces.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Get entities asynchronously
    /// </summary>
    /// <param name="filter">Filter the result</param>
    /// <param name="orderBy">Order the result</param>
    /// <param name="includeProperties">Include properties into the result, supports multiple properties separated by ',' character</param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");

    /// <summary>
    /// Get entity by Id asynchronously
    /// </summary>
    /// <param name="id">Entity identifier</param>
    /// <returns></returns>
    Task<TEntity?> GetByIdAsync(object id);

    /// <summary>
    /// Insert entity asynchronously
    /// </summary>
    /// <param name="entity">Entity to insert</param>
    /// <returns></returns>
    Task InsertAsync(TEntity entity);

    /// <summary>
    /// Save pending changes asynchronously
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task SaveChangeAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <returns></returns>
    void Update(TEntity entity);
}
