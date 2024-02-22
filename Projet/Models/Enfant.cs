using Projet.Models; // Assurez-vous que cette directive est présente si nécessaire



    namespace Projet.Models
{
    public class Enfant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public int IdParent { get; set; }

        // Nouvelles propriétés
        public decimal Prix { get; set; }
        public int AnneeProduction { get; set; }
        public string Type { get; set; }
    }
}
