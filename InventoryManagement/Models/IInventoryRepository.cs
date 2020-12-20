using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public interface IInventoryRepository
    {
        Inventory GetInventory(int Id);
        IEnumerable<Inventory> getAllInventory();
        Inventory Add(Inventory inventory);

        Inventory Update(Inventory inventoryToBeChanged);

        Inventory Delete(int Id);
    }
}
