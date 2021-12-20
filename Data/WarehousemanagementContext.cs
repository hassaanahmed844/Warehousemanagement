using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehousemanagement.Models;

namespace Warehousemanagement.Data
{
    public class WarehousemanagementContext : DbContext
    {
        public WarehousemanagementContext (DbContextOptions<WarehousemanagementContext> options)
            : base(options)
        {
        }

        public DbSet<Warehousemanagement.Models.Item> Item { get; set; }

        public DbSet<Warehousemanagement.Models.Product> Product { get; set; }

        public DbSet<Warehousemanagement.Models.Warehouse> Warehouse { get; set; }
    }
}
