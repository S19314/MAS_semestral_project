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
    public class ConversationController : Controller
    {

        private readonly IDataBaseService dataBaseService;
        // MAS_semestralContext dbContext = new MAS_semestralContext();
        private readonly ILogger<ConversationController> _logger;

        public ConversationController(ILogger<ConversationController> logger, IDataBaseService service)
        {
            _logger = logger;
            dataBaseService = service;
        }


        // GET: ConversationController
        public IActionResult Index()
        {
            // return View();
            return RedirectPermanent("/Conversation/List");
        }

        // GET: ConversationController/List
        public IActionResult List()
        {
            return View(dataBaseService.GetReceptionists());
        }


        // GET: ConversationController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ConversationController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConversationController/Create
        // Не мешает ли Валидация?
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

        // GET: ConversationController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConversationController/Edit/5
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

        // GET: ConversationController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConversationController/Delete/5
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
