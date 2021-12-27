using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehousemanagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Warehousemanagement.Data.WarehousemanagementContext _context;

        public IndexModel(ILogger<IndexModel> logger, Warehousemanagement.Data.WarehousemanagementContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public int ItemCount { get; set; }
        [BindProperty]
        public int ProductCount { get; set; }
        [BindProperty]
        public int WarehouseCount { get; set; }
        public void OnGet()
        {
            ItemCount = _context.Item.ToList().Count;
            ProductCount = _context.Product.ToList().Count;
            WarehouseCount = _context.Warehouse.ToList().Count;
        }
    }
}
