using System;
using System.Collections.Generic;

#nullable disable

namespace ShopBridgeModels
{
    public partial class Inventory
    {
        public int ID { get; set; }
        public string InventoryName { get; set; }
        public int InventoryType { get; set; }
        public string InventoryDescription { get; set; }
        public int InventoryPrice { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual lkpInventoryType InventoryTypeNavigation { get; set; }
    }
}
