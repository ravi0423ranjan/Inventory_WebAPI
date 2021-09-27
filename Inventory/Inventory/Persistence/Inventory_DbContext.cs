using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Persistence
{
    public class Inventory_DbContext : DbContext
    {
        public Inventory_DbContext(DbContextOptions<Inventory_DbContext> options) : base(options)
        {

        }

        public DbSet<ItemModel> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ItemModel>().HasData(
               new ItemModel
               {
                   ItemId = 1,
                   ItemCode = "VBN",
                   ItemName = "VBN",
                   ItemPrice = 25,
               },
               new ItemModel
               {
                   ItemId = 2,
                   ItemCode = "CDN",
                   ItemName = "CDN",
                   ItemPrice = 26,
               });
        }
        }
}
