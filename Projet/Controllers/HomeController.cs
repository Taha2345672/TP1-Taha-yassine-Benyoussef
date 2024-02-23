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
        [HttpGet("parent/ajouter")]
        public IActionResult AjouterParent()
        {
            return View(); // Créez une vue pour l'ajout d'un parent
        }

        [HttpPost("parent/ajouter")]
        public IActionResult AjouterParent(Parent parent)
        {
            if (ModelState.IsValid)
            {
                _baseDeDonnees.Parents.Add(parent);
                _baseDeDonnees.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parent);
        }

        [HttpGet("parent/editer/{id:int}")]
        public IActionResult EditerParent(int id)
        {
            var parent = _baseDeDonnees.Parents.FirstOrDefault(p => p.ParentId == id);

            if (parent == null)
            {
                return View("NotFound");
            }

            return View(parent);
        }

        [HttpPost("parent/editer/{id:int}")]
        public IActionResult EditerParent(int id, Parent parent)
        {
            if (ModelState.IsValid)
            {

                if (_baseDeDonnees.Parents.FirstOrDefault(p => p.ParentId == id) == null)
                {
                    return View("NotFound");
                }

               _baseDeDonnees.Parents.FirstOrDefault(p => p.ParentId == id).Nom = _baseDeDonnees.Parents.FirstOrDefault(p => p.ParentId == id).Nom;
                _baseDeDonnees.Parents.FirstOrDefault(p => p.ParentId == id).Description = _baseDeDonnees.Parents.FirstOrDefault(p => p.ParentId == id).Description;
                // Mettez à jour d'autres propriétés selon vos besoins

                _baseDeDonnees.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parent);
        }

        [HttpPost("parent/supprimer/{id:int}")]
        public IActionResult SupprimerParent(int id)
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

