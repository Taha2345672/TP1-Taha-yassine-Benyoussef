using Microsoft.AspNetCore.Mvc;
using Projet.Models;
using Projet.ViewModels;
using System.Linq;

public class EnfantController : Controller
{
    private readonly BaseDeDonnees _baseDeDonnees;
    private List<Enfant> enfant;

    public EnfantController(BaseDeDonnees baseDeDonnees)
    {
        _baseDeDonnees = baseDeDonnees;
    }

    [Route("Enfant/Recherche")]
    public IActionResult Recherche(CritereRechercheViewModel critereRecherche)


    {



        IEnumerable<Enfant> enfants = _baseDeDonnees.Enfants.ToList();


        if (!string.IsNullOrEmpty(critereRecherche.Nom))
        {
            enfants = enfants.Where(e => e.Nom.Contains(critereRecherche.Nom)).ToList();
        }

        if (critereRecherche.PrixMin.HasValue)
        {
            enfants = enfants.Where(e => e.Prix >= critereRecherche.PrixMin).ToList();
        }

        if (critereRecherche.PrixMax.HasValue)
        {
            enfants = enfants.Where(e => e.Prix <= critereRecherche.PrixMax).ToList();
        }


        if (critereRecherche.AdditionalFilter1)
        {
            enfants = enfants.Where(e => e.IdParent == 1);
        }


        if (critereRecherche.AdditionalFilter2)
        {
            enfants = enfants.Where(e => e.IdParent == 2);
        }


        if (critereRecherche.AdditionalFilter3)
        {
            enfants = enfants.Where(e => e.IdParent == 3);
        }

        if (!critereRecherche.EnVedette.HasValue)
        {
        }
        else
        {
            enfants = enfants.Where(e => e.EnVedette == critereRecherche.EnVedette.Value).ToList();
        }


        var viewModel = new PageRechercheViewModel
        {
            Resultats = (List<Enfant>)enfants,
            Criteres = critereRecherche
        };

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
