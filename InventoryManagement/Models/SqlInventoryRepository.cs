using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class SqlInventoryRepository : IInventoryRepository
    {
        private readonly InventoryDbContext context;
        public SqlInventoryRepository(InventoryDbContext context)
        {
            this.context = context;
        }
        public Inventory Add(Inventory inventory)
        {
            context.Inventories.Add(inventory);
            context.SaveChanges();
            return inventory;
        }

        public Inventory Delete(int Id)
        {
            Inventory inventory = context.Inventories.Find(Id);
            if (inventory != null)
            {
                context.Inventories.Remove(inventory);
                context.SaveChanges();
            }
            return inventory;
        }

        public IEnumerable<Inventory> getAllInventory()
        {
            return context.Inventories;
        }

        public Inventory GetInventory(int Id)
        {
            return context.Inventories.Find(Id);
        }

        public Inventory Update(Inventory inventoryToBeChanged)
        {
            var inventory = context.Inventories.Attach(inventoryToBeChanged);
            inventory.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return inventoryToBeChanged;
        }
    }
}
