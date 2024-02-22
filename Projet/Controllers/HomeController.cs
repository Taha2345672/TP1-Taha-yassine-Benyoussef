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
    }
}
