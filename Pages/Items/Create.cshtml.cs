using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehousemanagement.Data;
using Warehousemanagement.Models;

namespace Warehousemanagement.Pages.Items
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
            
        ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Id");
        ViewData["WearhouseId"] = new SelectList(_context.Set<Warehouse>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; }
        public IList<Warehouse> AllWarehouse { get; set; }
        public Warehouse Warehouse { get; set; }

        public IList<Product> AllProducts { get; set; }

        public Product Product { get; set; }
        public int MyProperty { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            AllProducts =  _context.Product.ToList();
            AllWarehouse = _context.Warehouse.ToList();
            Product = AllProducts.FirstOrDefault(m=> m.Id==Item.ProductId);
            Warehouse = AllWarehouse.FirstOrDefault(m => m.Id == Item.WearhouseId);
            if (Product.Length * Product.Width * Product.Height <= Warehouse.Volume)
            {
                Warehouse.Volume = Warehouse.Volume - Product.Length * Product.Width * Product.Height;
                _context.Attach(Warehouse).State = EntityState.Modified;
                _context.Item.Add(Item);
                await _context.SaveChangesAsync();
                _noty.Success("Item Added to "+Warehouse.Name+" Ware House Successfully", 5);
                return RedirectToPage("./Index");
            }
            else
            {
                int volumewar = Warehouse.Volume;
                _noty.Error("Ware House is out of Volume", 5);
            }


            return RedirectToPage("./Create");
        }
    }
}
