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
        /// Get Product by Id asynchronously
        /// </summary>
        /// <param name="id">Product Identitifer</param>
        /// <returns></returns>
        Task<Product?> GetByIdAsync(Guid id);

        /// <summary>
        /// Get Products asynchronously
        /// </summary>
        /// <param name="filter">Filter the result</param>
        /// <param name="orderBy">Order the result</param>
        /// <param name="includeProperties">Include properties into the result, supports multiple properties separated by ',' character</param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsAsync(Expression<Func<Product, bool>>? filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, string includeProperties = "");
       
        /// <summary>
        /// Mark Product as soft deleted
        /// </summary>
        /// <param name="product">Product to delete</param>
        /// <returns></returns>
        Task MarkAsDeleted(Product product);

        /// <summary>
        /// Update Product asynchronously
        /// </summary>
        /// <param name="product">Product to update</param>
        /// <returns></returns>
        Task UpdateAsync(Product product);
    }
}