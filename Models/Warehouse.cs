using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehousemanagement.Models
{
    public class Warehouse
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Wear House Name")]
        [StringLength(50)]
        public string Name { get; set; }
        public int Volume { get; set; }
        public string Address { get; set; }

    }
}
