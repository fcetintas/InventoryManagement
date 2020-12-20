using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    // 
    public class Inventory
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String DateBought { get; set; }
        [Required]
        public int SerialNumber { get; set; }
        [Required]
        public String OwnerName { get; set; }

    }
}
