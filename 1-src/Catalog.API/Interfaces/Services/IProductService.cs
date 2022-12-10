using System.Linq.Expressions;

namespace Catalog.API.Interfaces.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Add product asynchronously
        /// </summary>
        /// <param name="product">Product to add</param>
        /// <returns></returns>
        Task AddAsync(Product product);

        /// <summary>
        /// Get product by ID asynchronously
        /// </summary>
        /// <param name="id">Product identitifer</param>
        /// <returns></returns>
        Task<Product?> GetByIdAsync(Guid id);

        /// <summary>
        /// Get products asynchronously
        /// </summary>
        /// <param name="filter">Filter the result</param>
        /// <param name="orderBy">Order the result</param>
        /// <param name="includeProperties">Include properties into the result, supports multiple properties separated by ',' character</param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsAsync(Expression<Func<Product, bool>>? filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, string includeProperties = "");
       
        /// <summary>
        /// Mark product as soft deleted
        /// </summary>
        /// <param name="product">Product to delete</param>
        /// <returns></returns>
        Task MarkAsDeleted(Product product);

        /// <summary>
        /// Update product asynchronously
        /// </summary>
        /// <param name="product">Product to update</param>
        /// <returns></returns>
        Task UpdateAsync(Product product);
    }
}