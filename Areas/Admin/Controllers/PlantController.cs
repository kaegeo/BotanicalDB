using BotanicalDB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BotanicalDB.Areas.Admin.Controllers
{
    /*
     * Brett Fowler
     * Course CPT-231-424 - C# Programming II
     * Module 12 Assignnent
     * 2023 Fall
     */

    // Routing added to direct to Admin area
    [Area("Admin")]
    public class PlantController : Controller
    {
        private FowlerPlantContext plantContext { get; set; }

        public PlantController(FowlerPlantContext plantContext)
        {
            this.plantContext = plantContext;
        }

        // Routing added to direct to Admin area
        // authorize admin user to access admin controls
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        [HttpGet]
        public IActionResult Add()
        {
            // Viewbag variable for SpeciesComplex list
            ViewBag.Complexes = plantContext.SpeciesComplexes.ToList();
            return View(new Plant());
        }

        // Routing added to direct to Admin area
        // authorize admin user to access admin controls
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        [HttpPost]
        public IActionResult Add(Plant plant)
        {
            // Validation of modelstate
            if (ModelState.IsValid)
            {
                plantContext.Plants.Add(plant);
                plantContext.SaveChanges();
                // Set message to be set to TempData
                TempData["message"] = $"{plant.PlantName} was added to the database.";
                return RedirectToAction("Index", "Home");
            }
            // Viewbag variable for SpeciesComplex list
            ViewBag.Complexes = plantContext.SpeciesComplexes.ToList();
            return View(plant);
        }

        // Routing added to direct to Admin area
        // authorize admin user to access admin controls
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Plant plant = plantContext.Plants.Find(id);
            // Viewbag variable for SpeciesComplex list
            ViewBag.Complexes = plantContext.SpeciesComplexes.ToList();
            return View(plant);
        }

        // Routing added to direct to Admin area
        // authorize admin user to access admin controls
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        [HttpPost]
        public IActionResult Edit(Plant plant)
        {
            // Validation of modelstate
            if (ModelState.IsValid)
            {
                plantContext.Plants.Update(plant);
                plantContext.SaveChanges();
                // Set message to be set to TempData
                TempData["message"] = $"{plant.PlantName} was edited in the database.";
                return RedirectToAction("Index", "Home");
            }
            // Viewbag variable for SpeciesComplex list
            ViewBag.Complexes = plantContext.SpeciesComplexes.ToList();
            return View(plant);
        }

        // Routing added to direct to Admin area
        // authorize admin user to access admin controls
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Plant plant = plantContext.Plants.Find(id);
            plantContext.Plants.Remove(plant);
            plantContext.SaveChanges();
            // Set message to be set to TempData
            TempData["message"] = $"{plant.PlantName} was deleted from the database.";
            return RedirectToAction("Index", "Home");
        }
    }
}
