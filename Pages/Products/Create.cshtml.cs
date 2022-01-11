using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Warehousemanagement.Data;
using Warehousemanagement.Models;

namespace Warehousemanagement.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly Warehousemanagement.Data.WarehousemanagementContext _context;
        private readonly INotyfService _noty;
        public CreateModel(Warehousemanagement.Data.WarehousemanagementContext context, INotyfService noty)
        {
            _context = context;
            _noty = noty;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();
            _noty.Success("Product Added Successfully", 5);
            return RedirectToPage("./Index");
        }
    }
}
