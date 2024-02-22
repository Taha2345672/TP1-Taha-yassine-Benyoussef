using Microsoft.AspNetCore.Mvc;
using Projet.Models;
using System.Linq;

namespace Projet.Controllers
{
    public class FavorisController : Controller
    {
        private readonly BaseDeDonnees _baseDeDonnees;

        public FavorisController(BaseDeDonnees baseDeDonnees)
        {
            _baseDeDonnees = baseDeDonnees;
        }

        [Route("/favoris")]

        public IActionResult Index()
        {
            // Récupérer la liste des enfants depuis la base de données
            var enfants = _baseDeDonnees.Enfants.ToList();

            // Passer la liste des enfants à la vue
            return View(enfants);
        }
    }
}
