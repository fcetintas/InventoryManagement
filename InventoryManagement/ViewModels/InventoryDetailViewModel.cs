using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.ViewModels
{
    public class InventoryDetailViewModel
    {
        public Inventory inventory { get; set; }
        public String pageTitle { get; set; }

    }
}
