#region Namespaces
using Microsoft.EntityFrameworkCore;
using ShopBridgeDataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
#endregion

namespace ShopBridgeRepository
{
    public abstract class BaseRepository : IBaseRepository
    {
        /// <summary>
        /// Gets or sets the Data Context
        /// </summary>
        protected DbContext DbContext { get; private set; }

        /// <summary>
        ///  Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        protected BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbContext.Database.SetCommandTimeout(120);
        }

        /// <summary>
        /// Add entity in database
        /// </summary>
        /// <param name="entity">The object entity</param>
        /// <returns></returns>
        public virtual void Add<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Add(entity).State = EntityState.Added;
        }

        /// <summary>
        /// Delete specified entity from database
        /// </summary>
        /// <param name="entity">The object entity</param>
        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Entry(entity).State = EntityState.Deleted;
        }

        /// <summary>
        /// Update specified entity in database
        /// </summary>
        /// <param name="entity">The object entity</param>
        public virtual void Update<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Update(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Get entity by primary key
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns></returns>
        public async virtual Task<TEntity> GetEntityAsync<TEntity>(int id) where TEntity : class
        {
            return await DbContext.Set<TEntity>().FindAsync((object)id);

        }

        /// <summary>
        /// Get first or default entity by filter
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public async virtual Task<TEntity> GetEntityAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : class
        {

            return await DbContext.Set<TEntity>().FirstOrDefaultAsync<TEntity>(match);

        }

        /// <summary>
        /// Get Entity List
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetEntityListAsync<TEntity>() where TEntity : class
        {

            return await DbContext.Set<TEntity>().ToListAsync();

        }

        /// <summary>
        /// Get Entity List
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetEntityListAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : class
        {

            return await DbContext.Set<TEntity>().Where(match).ToListAsync();

        }

        /// <summary>
        /// Get Lookup entity list
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>Lookup entity list.</returns>
        public virtual async Task<IEnumerable<TEntity>> GetLookupEntityListAsync<TEntity>() where TEntity : class
        {

            Type type = typeof(TEntity);
            var lookupDataList = await GetEntityListAsync<TEntity>();
            return lookupDataList;

        }
    }
}
