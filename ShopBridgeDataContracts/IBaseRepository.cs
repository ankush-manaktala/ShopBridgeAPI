#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
#endregion

namespace ShopBridgeDataContracts
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Add<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity"></param>
        void Update<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Get Entity Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetEntityAsync<TEntity>(int id) where TEntity : class;

        /// <summary>
        /// Get Entity Async
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        Task<TEntity> GetEntityAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : class;

        /// <summary>
        /// Get entity List Async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetEntityListAsync<TEntity>() where TEntity : class;

        /// <summary>
        /// Get Entity List Async
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetEntityListAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : class;

        /// <summary>
        /// Get lookup data.
        /// </summary>
        /// <typeparam name="TEntity">Lookup type.</typeparam>
        /// <returns>Look up data.</returns>
        Task<IEnumerable<TEntity>> GetLookupEntityListAsync<TEntity>() where TEntity : class;
    }
}
