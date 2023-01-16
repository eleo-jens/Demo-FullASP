using Demo_ASP.Handlers;
using Demo_ASP.Models.ViewModels;
using Demo_BLL.Entities;
using Demo_Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Controllers
{
    public class SpectacleController : Controller
    {
        private readonly ISpectacleRepository<Spectacle, int> _services;

        public SpectacleController(ISpectacleRepository<Spectacle, int> services)
        {
            _services = services;
        }

        // GET: SpectacleController
        public ActionResult Index()
        {
            IEnumerable<SpectacleListItem> model = _services.Get().Select(e => e.ToListItem());
            return View(model);
        }

        // GET: SpectacleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpectacleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpectacleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: SpectacleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpectacleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: SpectacleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpectacleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
