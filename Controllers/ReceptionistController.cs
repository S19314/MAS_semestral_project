using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using MAS_semestral_project_MVS.DataBaseModels;
using MAS_semestral_project_MVS.Services;
using MAS_semestral_project_MVS.Models;

namespace MAS_semestral_project_MVS.Controllers
{
    public class ReceptionistController : Controller
    {

        private readonly IDataBaseService dataBaseService;
        // MAS_semestralContext dbContext = new MAS_semestralContext();
        private readonly ILogger<ReceptionistController> _logger;

        public ReceptionistController(ILogger<ReceptionistController> logger, IDataBaseService service)
        {
            _logger = logger;
            dataBaseService = service;
        }


        // GET: ReceptionistController
        public IActionResult Index()
        {
            // return View();
            return RedirectPermanent("/Receptionist/List");
        }

        // GET: ReceptionistController/List
        public IActionResult List()
        {
            return View(dataBaseService.GetReceptionists());
        }


        // GET: ReceptionistController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ReceptionistController/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateByInfo(string FirstName, string SecondName, int InternshipDaysInCurentHotel, decimal HourRate, PlaceWork[] PlaceWorks, KnowedLanguage[] KnowedLanguages, string WorkShift)
        {
            var receptionist = Person.CreateReceptionist(FirstName, SecondName, InternshipDaysInCurentHotel, HourRate, DateTime.Now, PlaceWorks, KnowedLanguages, WorkShift);
            dataBaseService.AddReceptionist(receptionist);
            return Redirect("List");
        }
        // POST: ReceptionistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReceptionistController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReceptionistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReceptionistController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReceptionistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] 
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
