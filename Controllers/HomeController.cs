using BotanicalDB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BotanicalDB.Controllers
{
    /*
     * Brett Fowler
     * Course CPT-231-424 - C# Programming II
     * Module 12 Assignnent
     * 2023 Fall
     */

    /* Cookies and session data being used to store favorite plant data
     * which is accessed through the Favorites navlink and displays the
     * number of favorites on the default area Index page
     */

    public class HomeController : Controller
    {
        private FowlerPlantContext plantContext {  get; set; }

        public HomeController(FowlerPlantContext plantContext)
        {
            this.plantContext = plantContext;
        }


        // Action to access and display plant table
        // Allow anonymous user to access index
        [AllowAnonymous]
        public IActionResult Index()
        {
            // Manage cookies and session data on start
            var session = new PlantSession(HttpContext.Session);
            List<Plant> myPlants = session.GetPlants();

            if (myPlants.Count == 0)
            {
                var cookies = new PlantCookies(Request.Cookies);
                string[] ids = cookies.GetMyPlantIds();

                if (ids.Length > 0)
                {
                    var myplants = plantContext.Plants
                        .Where(p => ids.Contains(p.PlantId.ToString()))
                        .ToList();
                    session.SetPlants(myplants);
                }
            }

            // Build index plant list
            List<Plant> plantList = plantContext.Plants.Include(p => p.Complex).ToList();
            return View(plantList);
        }

        // allow authorized user to access favorites
        [Authorize]
        [Route("[controller]/[action]")]
        public IActionResult Favorites()
        {
            List<Plant> plantList = plantContext.Plants.Include(p => p.Complex).ToList();
            return View(plantList);
        }

        // Routing added to direct to Default area
        // allow authorized user to access favorites
        [Authorize]
        [Route("[controller]/[action]/{id}")]
        // Action to add favorite plant to favorites list through session
        public IActionResult Favorite(int id)
        {
            PlantSession plantSession = new PlantSession(HttpContext.Session);
            PlantCookies plantCookies = new PlantCookies(Response.Cookies);

            List<Plant> plants = plantSession.GetPlants();
            Plant plant = plantContext.Plants.Find(id);
            if (plant != null)
            {
                if (plants.Where(p => p.PlantId == plant.PlantId).Select(p => p.PlantId).FirstOrDefault() == plant.PlantId)
                {
                    plants.Remove(plants.Where(p => p.PlantId == plant.PlantId).FirstOrDefault());
                }
                else
                {
                    plants.Add(plant);
                }
                plantSession.SetPlants(plants);
                plantCookies.SetMyPlantIds(plants);
            }
            return RedirectToAction("Index");
        }

        // allow authorized user to access complex list
        // Routing added to direct to Default area
        [Authorize]
        [Route("[controller]/[action]")]
        // Action to access and display speciescomplex table
        public IActionResult Complex()
        {
            List<SpeciesComplex> complexList = plantContext.SpeciesComplexes.ToList();
            return View(complexList);
        }

        // Routing added to direct to Default area
        [Route("[controller]/[action]")]
        public IActionResult Privacy()
        {
            return View();
        }

        // Routing added to direct to Default area
        [Route("[controller]/[action]")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}