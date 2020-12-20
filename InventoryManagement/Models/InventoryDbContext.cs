using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class InventoryDbContext: IdentityDbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options): base(options)
        {

        }

        public DbSet<Inventory> Inventories { get; set; }
    }
}
