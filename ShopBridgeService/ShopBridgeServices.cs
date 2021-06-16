using ShopBridgeDataContracts;
using ShopBridgeModels;
using ShopBridgeServiceContracts;
using ShopBridgeServiceContracts.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeService
{
    public class ShopBridgeServices:IShopBridgeService
    {
        #region private variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShopBridgeRepository _shopBridgeRepository;
        #endregion

        #region Constructor
        public ShopBridgeServices(IUnitOfWork unitOfWork, IShopBridgeRepository shopBridgeRepository)
        {
            _unitOfWork = unitOfWork;
            _shopBridgeRepository = shopBridgeRepository;
        }

        #endregion

        #region public methods

        public async Task<InventoryClientModel> GetInventory(int inventoryId)
        {
            try
            {
                InventoryClientModel Inventory = await _shopBridgeRepository.GetInventory(inventoryId);
                return Inventory;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<InventoryClientModel>> GetAllInventories()
        {
            try
            {
                var lstInventory = await _shopBridgeRepository.GetAllInventories();
                return lstInventory.ToList();
            }
             catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<string> AddUpdateInventory(InventoryClientModel inventory)
        {
            var strOutput = string.Empty;
            try
            {
                if (inventory.ID > 0)
                {
                    var inventoryDetails = await _shopBridgeRepository.GetEntityAsync<Inventory>(x => x.ID == inventory.ID && !x.IsDeleted);
                    inventoryDetails.InventoryName = inventory.InventoryName;
                    inventoryDetails.InventoryType = inventory.InventoryType;
                    inventoryDetails.InventoryDescription = inventory.InventoryDescription;
                    inventoryDetails.InventoryPrice = inventory.InventoryPrice;
                    inventoryDetails.ModifiedBy = 2;
                    inventoryDetails.ModifiedOn = DateTime.Now;
                    _shopBridgeRepository.Update(inventoryDetails);
                    strOutput = "update";
                }
                else
                {
                    Inventory inventoryDetails = new Inventory();
                    inventoryDetails.InventoryName = inventory.InventoryName;
                    inventoryDetails.InventoryType = inventory.InventoryType;
                    inventoryDetails.InventoryDescription = inventory.InventoryDescription;
                    inventoryDetails.InventoryPrice = inventory.InventoryPrice;
                    inventoryDetails.IsDeleted = false;
                    inventoryDetails.CreatedOn = DateTime.Now;
                    inventoryDetails.CreatedBy = 1;
                    _shopBridgeRepository.Add(inventoryDetails);
                    strOutput = "saved";
                }

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Record" + strOutput +"successfully!";   
        }

        public async Task DeleteInventoryItem(int inventoryId)
        {
            try
            {
                var inventoryDetails = await _shopBridgeRepository.GetEntityAsync<Inventory>(x => !x.IsDeleted && x.ID == inventoryId);
                inventoryDetails.IsDeleted = true;
                inventoryDetails.ModifiedBy = 2;
                inventoryDetails.ModifiedOn = DateTime.Now;
                _shopBridgeRepository.Update(inventoryDetails);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
