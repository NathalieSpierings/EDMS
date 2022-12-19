using System.Linq.Expressions;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain;

namespace Promeetec.EDMS.Data.Repositories
{
    /// <inheritdoc />
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected readonly EDMSDbContext _context;

        public Repository(EDMSDbContext context)
        {
            _context = context;
        }


        /// <inheritdoc />
        public IQueryable<T> Query()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        /// <inheritdoc />
        public async Task<T> AddAsync(T aggregate)
        {
            if (aggregate == null)
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                await _context.AddAsync(aggregate);
                await _context.SaveChangesAsync();

                return aggregate;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(aggregate)} could not be saved: {ex.Message}");
            }
        }

        /// <inheritdoc />
        public async Task<IQueryable<T>> AddRangeAsync(IQueryable<T> aggregates)
        {
            if (aggregates == null)
                throw new ArgumentNullException($"{nameof(AddAsync)} entities must not be null");


            try
            {
                await _context.AddRangeAsync(aggregates);
                await _context.SaveChangesAsync();

                return aggregates;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(aggregates)} could not be saved: {ex.Message}");
            }
        }

        /// <inheritdoc />
        public async Task<T> UpdateAsync(T aggregate)
        {
            if (aggregate == null)
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                _context.Update(aggregate);
                await _context.SaveChangesAsync();

                return aggregate;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(aggregate)} could not be updated: {ex.Message}");
            }
        }

        /// <inheritdoc />
        public async Task<T> RemoveAsync(T aggregate)
        {
            if (aggregate == null)
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                _context.Remove(aggregate);
                await _context.SaveChangesAsync();

                return aggregate;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(aggregate)} could not be updated: {ex.Message}");
            }
        }

        /// <inheritdoc />
        public async Task<IQueryable<T>> RemoveRangeAsync(IQueryable<T> aggregates)
        {
            if (aggregates == null)
                throw new ArgumentNullException($"{nameof(AddAsync)} entities must not be null");

            try
            {
                _context.RemoveRange(aggregates);
                await _context.SaveChangesAsync();

                return aggregates;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(aggregates)} could not be saved: {ex.Message}");
            }
        }

        /// <inheritdoc />
        public async Task<T?> GetByIdAsync(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException($"{nameof(GetByIdAsync)} identifier must not be null");

            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(id)} could not be found: {ex.Message}");
            }
        }

        /// <inheritdoc />
        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException($"{nameof(Find)} expression must not be null");

            try
            {
                return _context.Set<T>().Where(expression);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(expression)} could not be found: {ex.Message}");
            }
        }

        /// <inheritdoc />
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public IQueryable<T> FromSqlRaw(string sql, params object[] parameters)
        {
            return _context.Set<T>().FromSqlRaw(sql, parameters);
        }

        public IQueryable<TElement> SqlQuery<TElement>(FormattableString sql)
        {
            return _context.Database.SqlQuery<TElement>(sql);
        }
        public IQueryable<TElement> SqlQueryRaw<TElement>(string sql, params object[] parameters)
        {
            return _context.Database.SqlQueryRaw<TElement>(sql, parameters);
        }


        public int RawSQL(string sql)
        {
            var result = _context.Database.ExecuteSqlRaw(sql);
            return result;
        }

        public int RawSQL(string sql, params object[] parameters)
        {
            var result = _context.Database.ExecuteSqlRaw(sql, parameters);
            return result;
        }


        public async Task<int> RawSQLAsync(string sql)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(sql);
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> RawSQLAsync(string sql, params object[] parameters)
        {
            var result = await _context.Database.ExecuteSqlRawAsync(sql, parameters);
            return result;
        }
    }
}