using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.ModelResources
{
    public class ItemResource
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }

        public int ItemPrice { get; set; }

        public int ItemQty_InGms { get; set; }
    }
}
