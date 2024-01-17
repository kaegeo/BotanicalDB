using BotanicalDB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
    public class HomeController : Controller
    {
        private FowlerPlantContext plantContext { get; set; }

        public HomeController(FowlerPlantContext plantContext)
        {
            this.plantContext = plantContext;
        }

        // Action to access and display plant table
        // authorize admin user to access admin controls
        // Routing added to direct to Admin area
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            List<Plant> plantList = plantContext.Plants.Include(p => p.Complex).ToList();
            return View(plantList);
        }

        // Action to access and display speciescomplex table
        // Routing added to direct to Admin area
        // authorize admin user to access admin controls
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Complex()
        {
            List<SpeciesComplex> complexList = plantContext.SpeciesComplexes.ToList();
            return View(complexList);
        }

        // Routing added to direct to Admin area
        // authorize admin user to access admin controls
        [Authorize(Roles = "Admin")]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Privacy()
        {
            return View();
        }

        // Routing added to direct to Admin area
        [Route("[area]/[controller]/[action]")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
