using Microsoft.AspNetCore.Mvc;
using Projet.Models;

namespace Projet.Controllers
{
    public class HomeController : Controller
    {
        private readonly BaseDeDonnees _baseDeDonnees;

        public HomeController(BaseDeDonnees baseDeDonnees)
        {
            _baseDeDonnees = baseDeDonnees;
        }

        public IActionResult Index()
        {
            var parents = _baseDeDonnees.Parents;

            return View(parents);
        }
       // [HttpGet("parent/ajouter")]
        public IActionResult CreateParent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateParent(Parent parent)
        {
            if (ModelState.IsValid)
            {
                _baseDeDonnees.Parents.Add(parent);
                _baseDeDonnees.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parent);
        }

        [HttpGet("parent/UpdateParent/{id:int}")]
        public IActionResult UpdateParent(int id)
        {
            var parent = _baseDeDonnees.Parents.FirstOrDefault(p => p.ParentId == id);

            if (parent == null)
            {
                return View("NotFound");
            }

            return View(parent);
        }

        [HttpPost]
        public IActionResult UpdateParent(int id, Parent updatedParent)
        {
            if (ModelState.IsValid)
            {
                var existingParent = _baseDeDonnees.Parents.FirstOrDefault(p => p.ParentId == id);

                if (existingParent == null)
                {
                    return View("NotFound");
                }

                existingParent.Nom = updatedParent.Nom;
                existingParent.Description = updatedParent.Description;
                existingParent.ImageFileName = updatedParent.ImageFileName;

                _baseDeDonnees.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(updatedParent);
        }






        public IActionResult DeleteParent(int id)
        {
            var parent = _baseDeDonnees.Parents.FirstOrDefault(p => p.ParentId == id);

            if (parent == null)
            {
                return View("NotFound");
            }

            return View(parent);
        }

        [HttpPost]
        public IActionResult DeleteParentConfirmed(int id)
        {
            var parent = _baseDeDonnees.Parents.FirstOrDefault(p => p.ParentId == id);

            if (parent == null)
            {
                return View("NotFound");
            }

            _baseDeDonnees.Parents.Remove(parent);
            _baseDeDonnees.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}


