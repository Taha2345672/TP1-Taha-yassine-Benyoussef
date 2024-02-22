using Projet.Models;

namespace Projet.ViewModels
{
    public class PageRechercheViewModel
    {
        public List<Enfant> Resultats { get; set; }
        public CritereRechercheViewModel Criteres { get; set; }

    }
}