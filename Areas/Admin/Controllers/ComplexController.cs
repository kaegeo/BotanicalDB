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
    public class ComplexController : Controller
    {
        private FowlerPlantContext plantContext { get; set; }

        public ComplexController(FowlerPlantContext plantContext)
        {
            this.plantContext = plantContext;
        }

        // Routing added to direct to Admin area
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        [HttpGet]
        public IActionResult Add()
        {
            return View(new SpeciesComplex());
        }

        // Routing added to direct to Admin area
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        [HttpPost]
        public IActionResult Add(SpeciesComplex complex)
        {
            // Validation of modelstate
            if (ModelState.IsValid)
            {
                plantContext.SpeciesComplexes.Add(complex);
                plantContext.SaveChanges();
                // Set message to be set to TempData
                TempData["message"] = $"{complex.ComplexName} was added to the database.";
                return RedirectToAction("Complex", "Home");
            }
            return View(complex);
        }

        // Routing added to direct to Admin area
        // authorize admin user to access admin controls
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            SpeciesComplex complex = plantContext.SpeciesComplexes.Find(id);
            return View(complex);
        }

        // Routing added to direct to Admin area
        // authorize admin user to access admin controls
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        [HttpPost]
        public IActionResult Edit(SpeciesComplex complex)
        {
            // Validation of modelstate
            if (ModelState.IsValid)
            {
                plantContext.SpeciesComplexes.Update(complex);
                plantContext.SaveChanges();
                // Set message to be set to TempData
                TempData["message"] = $"{complex.ComplexName} was edited in the database.";
                return RedirectToAction("Complex", "Home");
            }
            return View(complex);
        }

        // Routing added to direct to Admin area
        // authorize admin user to access admin controls
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            SpeciesComplex complex = plantContext.SpeciesComplexes.Find(id);
            plantContext.SpeciesComplexes.Remove(complex);
            plantContext.SaveChanges();
            // Set message to be set to TempData
            TempData["message"] = $"{complex.ComplexName} was deleted from the database.";
            return RedirectToAction("Complex", "Home");
        }
    }
}
