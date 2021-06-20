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
    public class ClientController : Controller
    {

        private readonly IDataBaseService dataBaseService;
        // MAS_semestralContext dbContext = new MAS_semestralContext();
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger, IDataBaseService service)
        {
            _logger = logger;
            dataBaseService = service;
        }


        // GET: ClientController
        public IActionResult Index()
        {
            // return View();
            return RedirectPermanent("/Client/List");
        }

        // GET: ClientController/List
        public IActionResult List()
        {
            return View(dataBaseService.GetClients());
        }


        // GET: ClientController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
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

        // GET: ClientController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
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

        // GET: ClientController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
