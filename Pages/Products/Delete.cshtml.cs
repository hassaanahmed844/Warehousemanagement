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

namespace Warehousemanagement.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly Warehousemanagement.Data.WarehousemanagementContext _context;
        private readonly INotyfService _noty;
        public DeleteModel(Warehousemanagement.Data.WarehousemanagementContext context, INotyfService noty)
        {
            _context = context;
            _noty = noty;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FindAsync(id);

            if (Product != null)
            {
                _context.Product.Remove(Product);
                _noty.Success("Product Deleted Successfully", 5);
                await _context.SaveChangesAsync();
                
            }

            return RedirectToPage("./Index");
        }
    }
}
