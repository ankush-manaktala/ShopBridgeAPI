using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBridgeServiceContracts;
using ShopBridgeServiceContracts.BusinessModels;
using System;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopBridgeController : ControllerBase
    {
        private readonly ILogger<ShopBridgeController> _logger;
        private readonly IShopBridgeService _shopBridgeService;

        public ShopBridgeController(ILogger<ShopBridgeController> logger,IShopBridgeService shopBridgeService)
        {
            _logger = logger;
            _shopBridgeService = shopBridgeService;
        }

        #region public methods
        [HttpGet("GetInventory")]
        public async Task<ActionResult<InventoryClientModel>> GetInventory(int inventoryId)
        {
            try
            {
                var Inventory = await _shopBridgeService.GetInventory(inventoryId);
                return Ok(Inventory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllInventories")]
        public async Task<ActionResult<InventoryClientModel>> GetAllInventories()
        {
            try
            {
                var lstInventory = await _shopBridgeService.GetAllInventories();
                return Ok(lstInventory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("AddUpdateInventory")]
        public async Task<ActionResult<string>> AddUpdateInventory([FromBody] InventoryClientModel inventory)
        {
            var strOutPut = string.Empty;
            try
            {
                strOutPut = await _shopBridgeService.AddUpdateInventory(inventory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(strOutPut);
        }

        [HttpGet("DeleteInventoryItem")]
        public async Task<ActionResult<string>> DeleteInventoryItem(int inventoryId)
        {
            try
            {
                await _shopBridgeService.DeleteInventoryItem(inventoryId);
                return Ok("Successfully Deleted!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
