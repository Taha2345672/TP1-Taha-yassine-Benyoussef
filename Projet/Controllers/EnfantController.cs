using Microsoft.AspNetCore.Mvc;
using Projet.Models;
using Projet.ViewModels;
using System.Linq;

public class EnfantController : Controller
{
    private readonly BaseDeDonnees _baseDeDonnees;

    public EnfantController(BaseDeDonnees baseDeDonnees)
    {
        _baseDeDonnees = baseDeDonnees;
    }

    // Emplacement : Projet/Controllers/EnfantController.cs
    [Route("Enfant/Recherche")]
    public IActionResult Recherche()
    {
      
        var enfants = _baseDeDonnees.Enfants.ToList();

      
        var critereRecherche = new CritereRechercheViewModel
        {
          
            Nom = HttpContext.Request.Query["Nom"],
            PrixMin = Convert.ToDecimal(HttpContext.Request.Query["PrixMin"]),
            PrixMax = Convert.ToDecimal(HttpContext.Request.Query["PrixMax"]),
           
        };

        // Créez le modèle de vue
        var viewModel = new PageRechercheViewModel
        {
            Resultats = enfants,
            Criteres = critereRecherche
        };

        // Retournez la vue avec le modèle de vue
        return View(viewModel);
    }


    [HttpGet("enfant/detail/{id:int}", Name = "Detail")]

    public IActionResult DetailParId(int id)
    {
        var enfant = _baseDeDonnees.Enfants.SingleOrDefault(e => e.EnfantId == id);

        if (enfant == null)
        {
            return View("NotFound");
        }

        return View("Detail",enfant);
    }

    [HttpGet("enfant/detail/{nom}", Name = "DetailParNom")]
    [HttpGet("enfant/{nom}")]
    [HttpGet("{nom}")]
    public IActionResult DetailParNom(string nom)
    {
        
        nom = nom.ToUpper();

        var enfant = _baseDeDonnees.Enfants.FirstOrDefault(e => e.Nom.ToUpper() == nom);

        if (enfant == null)
        {
            return View("NotFound");
        }

        return View("Detail",enfant);

    }
}

