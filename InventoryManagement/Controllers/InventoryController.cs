using InventoryManagement.Models;
using InventoryManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventroyRepository)
        {
            _inventoryRepository = inventroyRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = _inventoryRepository.getAllInventory();

            return View(model);
        }

        [Authorize]
        public IActionResult Detail(int Id)
        {

            InventoryDetailViewModel inventoryDetailViewModel = new InventoryDetailViewModel()
            {
                inventory = _inventoryRepository.GetInventory(Id),
                pageTitle = "Inventory Detail"

            };

            return View(inventoryDetailViewModel);
        }

        [Authorize]
        [HttpGet] 
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                Inventory newInventory = _inventoryRepository.Add(inventory);
                return RedirectToAction("Detail", new { id = newInventory.Id });
            }
            return View();
            
        }

        [Authorize]
        public IActionResult Delete(int Id)
        {
            var inv = _inventoryRepository.Delete(Id);
            return RedirectToAction("Index", "Inventory");

        }

    }
}
