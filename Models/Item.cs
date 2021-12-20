using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehousemanagement.Models
{
    public class Item
    {

        public int Id { get; set; }

     
        public int Expirydate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiry Date")]
        public DateTime Expiry { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int WearhouseId { get; set; }
        public Warehouse Wearhouse { get; set; }


    }
}
