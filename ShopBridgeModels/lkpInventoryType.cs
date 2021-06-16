using System;
using System.Collections.Generic;

#nullable disable

namespace ShopBridgeModels
{
    public partial class lkpInventoryType
    {
        public lkpInventoryType()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int IT_ID { get; set; }
        public string IT_Type { get; set; }
        public string InventoryCode { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
