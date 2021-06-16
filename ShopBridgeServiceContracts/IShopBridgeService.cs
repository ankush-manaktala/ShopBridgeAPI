using ShopBridgeServiceContracts.BusinessModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridgeServiceContracts
{
    public interface IShopBridgeService
    {
        Task<InventoryClientModel> GetInventory(int inventoryId);

        Task<List<InventoryClientModel>> GetAllInventories();
        Task<string> AddUpdateInventory(InventoryClientModel inventory);
        Task DeleteInventoryItem(int inventoryId);
    }
}
