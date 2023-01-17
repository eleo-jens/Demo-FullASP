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
        // injection de dépendance; pour accéder au service du BLL pour pouvoir intérroger ma base de données
        // création d'un champ: readonly (get et private set)
        private readonly ISpectacleRepository<Spectacle, int> _services;

        // injection de dépendance via le controleur
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
            SpectacleDetails model = _services.Get(id).ToDetails();
            if (model is null)
            {
                TempData["Error"] = "Spectacle inexistant...";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: SpectacleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpectacleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpectacleCreateForm form)
        {
            if (!ModelState.IsValid) return View(form);
            int id = _services.Insert(form.ToBLL());
            return RedirectToAction("Details", new { id = id });
        }

        // GET: SpectacleController/Edit/5
        public ActionResult Edit(int id)
        {
            SpectacleEditForm model = _services.Get(id).ToEdit();
            if (model is null)
            {
                TempData["Error"] = "Spectacle inexistant...";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: SpectacleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SpectacleEditForm form)
        {
            if (!ModelState.IsValid) return View(form);
            if (!_services.Update(id, form.ToBLL()))
            {
                ViewBag.Error = "Erreur lors de la mise à jour... Réessayez.";
                return View(form);
            }
            return RedirectToAction("Details", new { id = id});
        }

        // GET: SpectacleController/Delete/5
        public ActionResult Delete(int id)
        {
            SpectacleDelete model = _services.Get(id).ToDelete();
            // si le model est null je ne peux pas rentré dans le formulaore
            if (model is null)
            {
                TempData["Error"] = "Spectacle inexistant...";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: SpectacleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SpectacleDelete form)
        {
            if (!_services.Delete(id))
            {
                TempData["Error"] = "Erreur de suppression...";
            }
            return RedirectToAction("Index");
        }
    }
}
