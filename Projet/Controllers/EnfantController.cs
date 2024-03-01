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

        return View("Detail", enfant);
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

        return View("Detail", enfant);
    }
    [HttpPost("Creation")]
    public IActionResult Creation(Enfant enfant)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (_baseDeDonnees.Enfants.Any(e => e.EnfantId == enfant.EnfantId))
                {
                    // L'enfant avec cet ID existe déjà, vous pouvez traiter cela en conséquence.
                    // Peut-être une redirection vers une vue d'erreur.
                    return RedirectToAction("Erreur", "Enfant");
                }

                _baseDeDonnees.Enfants.Add(enfant);
                _baseDeDonnees.SaveChanges();
                return RedirectToAction("Recherche");
            }
        }
        catch (Exception ex)
        {
            // Loguez l'exception pour un débogage ultérieur.
            Console.WriteLine(ex.Message);
            // Vous pouvez rediriger vers une vue d'erreur ou effectuer d'autres actions.
            return RedirectToAction("Erreur", "Enfant");
        }

        return View(enfant);
    }


    // édition 
    [HttpGet("Edition/{id:int}")]
    public IActionResult Edition(int id)
    {
        var enfant = _baseDeDonnees.Enfants.SingleOrDefault(e => e.EnfantId == id);

        if (enfant == null)
        {
            return View("NotFound");
        }

        return View(enfant);
    }

    [HttpPost("Edition/{id:int}")]
    public IActionResult update (int id, Enfant enfantModifie)
    {
        var enfant = _baseDeDonnees.Enfants.SingleOrDefault(e => e.EnfantId == id);

        if (enfant == null)
        {
            return View("NotFound");
        }

        if (ModelState.IsValid)
        {
            
            enfant.Nom = enfantModifie.Nom;
            enfant.Prix = enfantModifie.Prix;
            _baseDeDonnees.SaveChanges();
            return RedirectToAction("Recherche"); 
        }

       
        return View(enfant);
    }

    //  suppression 
    [HttpPost("Suppression/{id:int}")]
    public IActionResult Delete (int id)
    {
        var enfant = _baseDeDonnees.Enfants.SingleOrDefault(e => e.EnfantId == id);

        if (enfant == null)
        {
            return View("NotFound");
        }

        _baseDeDonnees.Enfants.Remove(enfant);
        _baseDeDonnees.SaveChanges();

        return RedirectToAction("Recherche"); // Redirige vers la liste des enfants après la suppression
    }
}
