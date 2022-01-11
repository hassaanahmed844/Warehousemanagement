using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehousemanagement.Data;
using Warehousemanagement.Models;

namespace Warehousemanagement.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Warehousemanagement.Data.WarehousemanagementContext _context;

        public IndexModel(Warehousemanagement.Data.WarehousemanagementContext context)
        {
            _context = context;
        }

        public string Name { get; set; }
        public IList<Product> Product { get;set; }

        public async Task OnGetAsync(string Name, string task)
        {
            if (task == "Search")
                Product = await _context.Product.Where(m => m.Name.ToLower() == Name.ToLower()).ToListAsync();
            else
                Product = await _context.Product.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(string Name, string task)
        {

            return RedirectToPage("",new{ Name = Name, task=task});
        }
    }
}
