using BotanicalDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BotanicalDB.Areas.Help.Controllers
{
    /*
     * Brett Fowler
     * Course CPT-231-424 - C# Programming II
     * Module 12 Assignnent
     * 2023 Fall
     */

    // Routing added to direct to Help area
    [Area("Help")]
    public class HomeController : Controller
    {
        // Routing added to direct to Help page 1
        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }

        // Routing added to direct to Help page 2
        [Route("[area]/[controller]/[action]")]
        public IActionResult PageTwo()
        {
            return View();
        }

        // Routing added to direct to Help page 3
        [Route("[area]/[controller]/[action]")]
        public IActionResult PageThree()
        {
            return View();
        }

        // Routing added to direct to Help area
        [Route("[area]/[controller]/[action]")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
