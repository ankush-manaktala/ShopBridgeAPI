using ShopBridgeServiceContracts.BusinessModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridgeDataContracts
{
    public interface IShopBridgeRepository:IBaseRepository
    {
        Task<InventoryClientModel> GetInventory(int inventoryId);
        Task<List<InventoryClientModel>> GetAllInventories();
    }
}
