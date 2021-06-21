using MAS_semestral_project_MVS.Models;
using MAS_semestral_project_MVS.DataBaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MAS_semestral_project_MVS.Services;
using MAS_semestral_project_MVS.Models.Views;

namespace MAS_semestral_project_MVS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataBaseService dataBaseService;
            // MAS_semestralContext dbContext = new MAS_semestralContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IDataBaseService service)
        {
            _logger = logger;
            dataBaseService = service;
        }

        public IActionResult Index()
        {


            // model data
            // Example: db.Courses.Include(c => c.Students).ToList();
            // var clients = dataBaseService.GetClients();
            var clients = dataBaseService.GetClientsConnectedWithEmployeeByConversation();
            var receptionists = dataBaseService.GetReceptionists();
            var homeModelView = new HomeModelView { Clients = clients, Receptionists = receptionists };
            return View(homeModelView);
        }

        public IActionResult FindByReceptionistClients(Person receptionist) 
        {
            var clients = CustomerConversation.GetClients(receptionist.CustomerConversationEmployeeIdOsobaNavigations);
            // var clients = CustomerConversation.GetClients(receptionist.CustomerConversationClientIdOsobaNavigations);
            var receptionists = new List<Person>();
            receptionists.Add(receptionist);
            ViewData["my_info"] = "rECPTIONISTliSTLength: " + receptionists.Count() + "\nclients.Count(): " + clients.Count() +
                "\nreceptionist.CustomerConversationClientIdOsobaNavigations" + receptionist.CustomerConversationClientIdOsobaNavigations.Count() 
                + "\n receptionist.CustomerConversationEmployeeIdOsobaNavigations" + receptionist.CustomerConversationEmployeeIdOsobaNavigations.Count();
            var homeModelView = new HomeModelView { Clients = clients, Receptionists = receptionists };
            // Немнеог нужно изменить.
            return View("Index", homeModelView);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        ///  Show all Clients in DataBase. 
        /// </summary>
        /// <returns></returns>
        public IActionResult Clients()
        {

           return View();
        }
        /*
        public IActionResult HelloWorld()
        {
            return PartialView("HelloWorldView");
        }
        */
        public IActionResult MenuShowElements() 
        {
            ViewData["navigation_title_page"] = "menu_show_elements";
            return View();
        }
        
        public IActionResult MenuRegisterNewElement()
        {
            ViewData["navigation_title_page"] = "menu_register_elements";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
