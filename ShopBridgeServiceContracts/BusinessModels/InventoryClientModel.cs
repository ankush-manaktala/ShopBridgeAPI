using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeServiceContracts.BusinessModels
{
    public class InventoryClientModel
    {
        public int ID { get; set; }
        public string InventoryName { get; set; }
        public string InventoryTypeName { get; set; }
        public int InventoryType { get; set; }
        public string InventoryDescription { get; set; }
        public int InventoryPrice { get; set; }
    }
}
