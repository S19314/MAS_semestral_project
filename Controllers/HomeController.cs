using MAS_semestral_project_MVS.Models;
using MAS_semestral_project_MVS.DataBaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MAS_semestral_project_MVS.Controllers
{
    public class HomeController : Controller
    {
        private readonly MAS_semestralContext dbContext = new MAS_semestralContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Show all Clients in DataBase.
        /// </summary>
        public IActionResult Clients()
        {
            return View();
            // return null; 
            // return View(dbContext.People.ToList().Where(e => e.RelationWithCompany.Equals("Client")));
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
