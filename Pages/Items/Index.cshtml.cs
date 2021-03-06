using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehousemanagement.Data;
using Warehousemanagement.Models;

namespace Warehousemanagement.Pages.Items
{
    
    public class IndexModel : PageModel
    {
        private readonly Warehousemanagement.Data.WarehousemanagementContext _context;
        private readonly INotyfService _noty;
        public IndexModel(Warehousemanagement.Data.WarehousemanagementContext context, INotyfService noty)
        {
            _context = context;
            _noty = noty;
        }
        public IList<Item> Item { get;set; }
        public IList<Product> AllProducts { get; set; }
        public Product Product { get; set; }
        public async Task OnGetAsync()
        {
            Item = await _context.Item
                .Include(i => i.Product)
                .Include(i => i.Wearhouse).ToListAsync();
            AllProducts = await _context.Product.ToListAsync();
            //_noty.Success("Welcome", 5);
        }
    }
}
