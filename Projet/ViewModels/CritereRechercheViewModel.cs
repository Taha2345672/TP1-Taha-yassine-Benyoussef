namespace Projet.ViewModels
{
    public class CritereRechercheViewModel
    {
        public string SearchTerm { get; set; }

        public string Nom { get; set; }
        public decimal? PrixMin { get; set; }
        public decimal? PrixMax { get; set; }
        public string Devise { get; set; }
        public string EnfantVedette { get; set; }
        public bool ParentFilter { get; set; }
        public bool AdditionalFilter1 { get; set; }
        public bool AdditionalFilter2 { get; set; }
        public bool AdditionalFilter3 { get; set; }


        public bool? EnVedette { get; set; }


    }
}
