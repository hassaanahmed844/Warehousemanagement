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
    public class DetailsModel : PageModel
    {
        private readonly Warehousemanagement.Data.WarehousemanagementContext _context;

        public DetailsModel(Warehousemanagement.Data.WarehousemanagementContext context)
        {
            _context = context;
        }

        public Warehouse Warehouse { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Warehouse = await _context.Warehouse.FirstOrDefaultAsync(m => m.Id == id);

            if (Warehouse == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
