using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class ItemModel
    {
        [Key]
        [Required]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }

        public int ItemPrice { get; set; }

        public int ItemQty_InGms { get; set; }
    }
}
