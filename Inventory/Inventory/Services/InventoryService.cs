using AutoMapper;
using Inventory.ModelResources;
using Inventory.Models;
using Inventory.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Services
{

    public interface IInventoryInterface
    {
        Task<List<ItemModel>> GetAllItems();

        Task<ItemResource> CreateItem(ItemResource itemResource);

        Task<ItemResource> EditItem(int id,ItemResource itemResource);

        Task<ItemResource> DeleteItem(int id);


    }
    public class InventoryService : IInventoryInterface
    {
        private readonly Inventory_DbContext context;
        private readonly IMapper mapper;

        public InventoryService(Inventory_DbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<ItemModel>> GetAllItems()
        {
            return await context.Items.ToListAsync();
        }

        public async Task<ItemResource> CreateItem(ItemResource itemResource)
        {
            var item = mapper.Map<ItemResource, ItemModel>(itemResource);
            context.Items.Add(item);
            await context.SaveChangesAsync();
            return mapper.Map<ItemModel, ItemResource>(item);
        }

        public async Task<ItemResource> EditItem(int id,ItemResource itemResource)
        {
            var item = await context.Items.FirstOrDefaultAsync(exp => exp.ItemId == id);

            item.ItemCode = itemResource.ItemCode;
            item.ItemName = itemResource.ItemName;
            item.ItemPrice = itemResource.ItemPrice;
            item.ItemQty_InGms = itemResource.ItemQty_InGms;

            context.Items.Update(item);
            await context.SaveChangesAsync();
            return mapper.Map<ItemModel, ItemResource>(item);
        }

        public async Task<ItemResource> DeleteItem(int id)
        {
            var item = await context.Items.FirstOrDefaultAsync(exp => exp.ItemId == id);
            context.Items.Remove(item);
            await context.SaveChangesAsync();
            return mapper.Map<ItemModel, ItemResource>(item);
        }

    }
}
