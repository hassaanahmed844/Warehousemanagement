using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehousemanagement.Data;
using Warehousemanagement.Models;

namespace Warehousemanagement.Pages.Warehouses
{
    public class IndexModel : PageModel
    {
        private readonly Warehousemanagement.Data.WarehousemanagementContext _context;

        public IndexModel(Warehousemanagement.Data.WarehousemanagementContext context)
        {
            _context = context;
        }

        public IList<Warehouse> Warehouse { get;set; }

        public async Task OnGetAsync()
        {
            Warehouse = await _context.Warehouse.ToListAsync();
        }
    }
}
