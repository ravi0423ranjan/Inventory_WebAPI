using Inventory.ModelResources;
using Inventory.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Controllers
{
    [Route("api/[Controller]")]
    public class InventoryController : Controller
    {
        private readonly ILogger<InventoryController> logger;
        private readonly IInventoryInterface inventoryService;

        public InventoryController(ILogger<InventoryController> logger, IInventoryInterface inventoryService)
        {
            this.logger = logger;
            this.inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemsList()
        {
            try
            {
                var items = (from item in await inventoryService.GetAllItems()
                             select new
                             {
                                 ItemCode = item.ItemCode,
                                 ItemName = item.ItemName,
                                 ItemPrice = item.ItemPrice,
                                 ItemQuantity = item.ItemQty_InGms
                             });
                return Ok(items);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Source + "-" + ex.Message);
                return BadRequest();
            }
        }

            [HttpPost]
            public async Task<IActionResult> CreateItem([FromBody] ItemResource itemResource)
            {
                try
                {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var item = await inventoryService.CreateItem(itemResource);
                var result= new {ItemCode = item.ItemCode,ItemName=item.ItemName,ItemPrice=item.ItemPrice,ItemQuantity=item.ItemQty_InGms};
                return Ok(result);
                }
                catch (Exception ex)
                {
                  logger.LogError(ex.Source + "-" + ex.Message);
                  return BadRequest();
                }
            }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int ?id,[FromBody] ItemResource itemResource)
        {
            try
            {
                if ((id ?? 0) == 0) { return BadRequest(ModelState); }
                if (id != itemResource.ItemId) { return BadRequest(); }
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var item = await inventoryService.EditItem(id ?? 0,itemResource);
                var result = new { ItemCode = item.ItemCode, ItemName = item.ItemName, ItemPrice = item.ItemPrice, ItemQuantity = item.ItemQty_InGms };
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Source + "-" + ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> DeleteItem(int? id)
        {
            try
            {
                if ((id ?? 0) == 0) { return BadRequest(ModelState); }
                var item = await inventoryService.DeleteItem(id ?? 0);
                var result = new { ItemCode = item.ItemCode, ItemName = item.ItemName, ItemPrice = item.ItemPrice, ItemQuantity = item.ItemQty_InGms };
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Source + "-" + ex.Message);
                return BadRequest();
            }
        }
    }
}
