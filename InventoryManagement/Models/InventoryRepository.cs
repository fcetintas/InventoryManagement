using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventoryList;

        public InventoryRepository()
        {
            /*_inventoryList = new List<Inventory>()
            {
                new Inventory(){Id: 1 ,  }
            };
            */

        }

        private List<Inventory> GetInventoryList()
        {
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText("jsonDb.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Inventory> tmpList = (List<Inventory>)serializer.Deserialize(file, typeof(List<Inventory>));
                this._inventoryList = tmpList;
            }
            if (_inventoryList == null || _inventoryList.Count <= 0)
            {
                return new List<Inventory>() {
                    new Inventory(){Id = 0, Name = "Default", DateBought = "01.01.2020" ,OwnerName = "default", SerialNumber = 111111 }
                };
            }
            return _inventoryList;
        }
        
        private List<Inventory> SaveInventoryList(List<Inventory> inventoryList)
        {
            //open file stream
            using (StreamWriter file = File.CreateText("jsonDb.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, inventoryList);
            }

            
            return _inventoryList;
        }

        public Inventory Add(Inventory inventory)
        {
            List<Inventory> tmpList = GetInventoryList();
            // check if inventory list has any element in it
            if( tmpList == null || tmpList.Count <= 0)
            {
                inventory.Id = 1;
            }
            else
            {
                inventory.Id = GetInventoryList().Max(e => e.Id) + 1;
            }
            tmpList.Add(inventory);
            SaveInventoryList(tmpList);
            return inventory;
        }

        public Inventory Delete(int Id)
        {
            List<Inventory>  tmpList = GetInventoryList();
            Inventory inventory = tmpList.FirstOrDefault(e => e.Id == Id);
            if (inventory != null)
            {
                tmpList.Remove(inventory);
            }
            SaveInventoryList(tmpList);
            return inventory;
        }

        public IEnumerable<Inventory> getAllInventory()
        {
            return GetInventoryList();
        }

        public Inventory GetInventory(int Id)
        {
            return GetInventoryList().FirstOrDefault(e => e.Id == Id);
        }

        public Inventory Update(Inventory inventoryToBeChanged)
        {
            List<Inventory> tmpList = GetInventoryList();
            Inventory inventory = tmpList.FirstOrDefault(e => e.Id == inventoryToBeChanged.Id);
            if (inventory != null)
            {
                inventory.Name = inventoryToBeChanged.Name;
                inventory.OwnerName = inventoryToBeChanged.OwnerName;
                inventory.SerialNumber = inventoryToBeChanged.SerialNumber;
                inventory.DateBought = inventoryToBeChanged.DateBought;
            }
            SaveInventoryList(tmpList);
            return inventory;
        }
    }
}
