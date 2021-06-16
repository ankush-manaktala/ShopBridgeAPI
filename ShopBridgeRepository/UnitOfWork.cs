using Microsoft.EntityFrameworkCore;
using ShopBridgeDataContracts;
using ShopBridgeRepository.ShopBridgeContexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        /// <summary>
        /// Gets or sets the Data context property
        /// </summary>
        private readonly ShopBridgeContext _shopBridgeContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Intilializes the context
        /// </summary>
        /// <param name="ruleContext"></param>  
        public UnitOfWork(ShopBridgeContext shopBridgeContext)
        {
            _shopBridgeContext = shopBridgeContext;
        }
        #endregion

        #region Methods

        #region Private Methods


        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>      
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (_shopBridgeContext == null)
                return;

            _shopBridgeContext.Dispose();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Commit data asyncroniously
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CommitAsync()
        {
            try
            {
                await _shopBridgeContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                var changedEntries = _shopBridgeContext.ChangeTracker.Entries()
                                    .Where(x => x.State != EntityState.Unchanged).ToList();
                foreach (var entry in changedEntries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Unchanged;
                            break;
                    }
                }
                throw ex;
            }
        }


        /// <summary>
        /// Disposes the current object
        /// </summary>      
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        #endregion

        #endregion

    }
}
