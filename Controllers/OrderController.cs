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
    public class OrderController : Controller
    {

        private readonly IDataBaseService dataBaseService;
        // MAS_semestralContext dbContext = new MAS_semestralContext();
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IDataBaseService service)
        {
            _logger = logger;
            dataBaseService = service;
        }


        // GET: OrderController
        public IActionResult Index()
        {
            // return View();
            return RedirectPermanent("/Order/List");
        }

        // GET: OrderController/List
        public IActionResult List()
        {
            return View(dataBaseService.GetOrders());
        }


        // GET: OrderController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
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

        // GET: OrderController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
