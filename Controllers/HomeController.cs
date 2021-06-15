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
        ///  Show all Clients in DataBase. 
        /// </summary>
        /// <returns></returns>
        public IActionResult Clients()
        {
            var person = dbContext.People.Where(e => e.IdOsoba == 11).First();
            ViewData["person"] = person;
            var languages = dbContext.LanguageEmployees.ToList();
            var languagesToString = LanguageEmployee.ListToString(languages);
            
            
            // toString();
            // var knowedLanguage = person.LanguageEmployees.Where(e => e.KnowedLanguageIdLanguage > 1).First(); // Не работаетю...
            var allLanguagesToString = LanguageEmployee.ListToString( person.LanguageEmployees.ToList()); // Не работаетю...
            var languageByEmployeeToString = person.LanguageEmployees.Where(e => e.KnowedLanguageIdLanguage == 11).First().ToString(); 
            var languageByEmployee = person.LanguageEmployees.Where(e => e.KnowedLanguageIdLanguage == 11).First();
            var employeeByLanguageToString = languageByEmployee.OsobaIdOsobaNavigation.GetPersonShortInfo();
            /*
            var personByKnowedLanguage = knowedLanguage.OsobaIdOsobaNavigation;
            var isEqualPerson = personByKnowedLanguage.Equals(person);
            
            
            ViewData["personToString"] = person.GetPersonShortInfo();
            
            ViewData["personByKnowedLanguage"] = personByKnowedLanguage;
            ViewData["isEqualPerson"] = isEqualPerson;
            */
            
            ViewData["languagesToString"] = languagesToString;
            ViewData["allLanguagesToString"] = allLanguagesToString;
            ViewData["languageByEmployeeToString"] = languageByEmployeeToString;
            ViewData["employeeByLanguageToString"] = employeeByLanguageToString;
            return View(ViewData);
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
