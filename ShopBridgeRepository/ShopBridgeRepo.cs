using Microsoft.EntityFrameworkCore;
using ShopBridgeDataContracts;
using ShopBridgeModels;
using ShopBridgeRepository.ShopBridgeContexts;
using ShopBridgeServiceContracts.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeRepository
{
    public class ShopBridgeRepo:BaseRepository,IShopBridgeRepository
    {
        #region private variables
        private readonly ShopBridgeContext _shopBridgeContext;
        #endregion

        public ShopBridgeRepo(ShopBridgeContext shopBridgeContext):base(shopBridgeContext)
        {
            _shopBridgeContext = shopBridgeContext;
        }

        public async Task<InventoryClientModel> GetInventory(int inventoryId)
        {
            try
            {
                var Inventory = await _shopBridgeContext.Inventories.Include(x => x.InventoryTypeNavigation).Where(x => !x.IsDeleted && x.ID == inventoryId).Select(x => new InventoryClientModel
                {
                    ID = x.ID,
                    InventoryName = x.InventoryName,
                    InventoryDescription = x.InventoryDescription,
                    InventoryPrice = x.InventoryPrice,
                    InventoryTypeName = x.InventoryTypeNavigation.IT_Type,
                    InventoryType=x.InventoryType

                }).FirstOrDefaultAsync();

                return Inventory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<InventoryClientModel>> GetAllInventories()
        {
            try
            {
                var lstInventory = await _shopBridgeContext.Inventories.Include(x => x.InventoryTypeNavigation).Where(x=>!x.IsDeleted).Select(x => new InventoryClientModel
                {
                    ID = x.ID,
                    InventoryName = x.InventoryName,
                    InventoryDescription = x.InventoryDescription,
                    InventoryPrice = x.InventoryPrice,
                    InventoryTypeName = x.InventoryTypeNavigation.IT_Type,
                    InventoryType = x.InventoryType
                }).ToListAsync();
                return lstInventory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
