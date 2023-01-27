using System.Linq.Expressions;

namespace Promeetec.EDMS.Portaal.Core.Domain
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        /// <summary>
        /// Query the context.
        /// </summary>
        /// <returns>The aggregate table.</returns>
        IQueryable<T> Query();

        /// <summary>
        /// Adds the specified aggregate asynchronous.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        Task<T> AddAsync(T aggregate);
        
        /// <summary>
        /// Adds the specified aggregates asynchronous.
        /// </summary>
        /// <param name="aggregates">The aggregates.</param>
        Task<IQueryable<T>> AddRangeAsync(IQueryable<T> aggregates);

        /// <summary>
        /// Updates the specified aggregate asynchronous.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        Task<T> UpdateAsync(T aggregate);

        /// <summary>
        /// Removes the specified aggregate asynchronous.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        Task<T> RemoveAsync(T aggregate);


        /// <summary>
        /// Removes the specified aggregates asynchronous.
        /// </summary>
        /// <param name="aggregates">The aggregates.</param>
        Task<IQueryable<T>> RemoveRangeAsync(IQueryable<T> aggregates);

        /// <summary>
        /// Finds the aggregate by the given identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns>The aggregate.</returns>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Get's the aggregate by the expression.
        /// </summary>
        /// <param name="expression">The find expression.</param>
        /// <returns>The aggregate.</returns>
        IQueryable<T> Find(Expression<Func<T, bool>> expression);


        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}