using System;
using System.Collections.Generic;
using System.Text;



namespace Projet.Models
{
    public class BaseDeDonnees
    {
        public List<Parent> Parents { get; set; } = new List<Parent>();
        public List<Enfant> Enfants { get; set; } = new List<Enfant>();
        public BaseDeDonnees()
        {
            Enfants = new List<Enfant>();
            Parents = new List<Parent>();


            // Ajout des parents
            Parents.Add(new Parent() { Id = 1, Nom = "CESSNA", ImageFileName = "CESSNA.png" });
            Parents.Add(new Parent() { Id = 2, Nom = "PIPER", ImageFileName = "PIPER.png" });
            Parents.Add(new Parent() { Id = 3, Nom = "CIRRUS", ImageFileName = "CIRRUS.png" });


   // Ajout des enfants associés au parent CESSNA (IdParent = 1)
Enfants.Add(new Enfant() { Id = 1, Nom = "Cessna 172", Description = "Avion monomoteur léger.", ImageFileName = "cessna 172 1.png", IdParent = 1, Prix = 100000, AnneeProduction = 2005, Type = "Monomoteur" });
Enfants.Add(new Enfant() { Id = 2, Nom = "Cessna 152", Description = "Avion monomoteur léger.", ImageFileName = "cessna 152 2.png", IdParent = 1, Prix = 80000, AnneeProduction = 2002, Type = "Monomoteur" });
Enfants.Add(new Enfant() { Id = 3, Nom = "Cessna 182", Description = "Avion monomoteur à pistons.", ImageFileName = "CESSNA 182 1.png", IdParent = 1, Prix = 120000, AnneeProduction = 2008, Type = "Monomoteur" });
Enfants.Add(new Enfant() { Id = 4, Nom = "Cessna Citation", Description = "Jet d'affaires léger à réaction.", ImageFileName = "Carravan.png", IdParent = 1, Prix = 500000, AnneeProduction = 2015, Type = "Jet" });

// Ajout des enfants associés au parent PIPER (IdParent = 2)
Enfants.Add(new Enfant() { Id = 5, Nom = "Piper Archer", Description = "Avion léger à quatre places.", ImageFileName = "Archer 1.png", IdParent = 2, Prix = 90000, AnneeProduction = 2010, Type = "Léger" });
Enfants.Add(new Enfant() { Id = 6, Nom = "Piper Cherokee", Description = "Avion monomoteur à ailes hautes.", ImageFileName = "CHEROKEE 1.png", IdParent = 2, Prix = 75000, AnneeProduction = 2007, Type = "Monomoteur" });
Enfants.Add(new Enfant() { Id = 7, Nom = "Piper PA24", Description = "Avion léger de sport.", ImageFileName = "PIPER PA24.png", IdParent = 2, Prix = 80000, AnneeProduction = 2009, Type = "Léger" });
Enfants.Add(new Enfant() { Id = 8, Nom = "Piper PA28", Description = "Avion monomoteur léger et rapide.", ImageFileName = "piper pa28.png", IdParent = 2, Prix = 100000, AnneeProduction = 2012, Type = "Monomoteur" });

// Ajout des enfants associés au parent CIRRUS (IdParent = 3)
Enfants.Add(new Enfant() { Id = 9, Nom = "Cirrus SR22T", Description = "Jet d'affaires monoréacteur.", ImageFileName = "SR22T 1.png", IdParent = 3, Prix = 600000, AnneeProduction = 2018, Type = "Jet" });
Enfants.Add(new Enfant() { Id = 10, Nom = "Cirrus SR22", Description = "Avion monomoteur à pistons de haute performance.", ImageFileName = "SR22 1.png", IdParent = 3, Prix = 300000, AnneeProduction = 2015, Type = "Monomoteur" });
Enfants.Add(new Enfant() { Id = 11, Nom = "Cirrus SR20", Description = "Avion à réaction légère.", ImageFileName = "SR20 1.png", IdParent = 3, Prix = 200000, AnneeProduction = 2013, Type = "Monomoteur" });
Enfants.Add(new Enfant() { Id = 12, Nom = "Cirrus Vision Jet", Description = "Jet monomoteur à réaction de type Vision Jet.", ImageFileName = "VISON JET 1.png", IdParent = 3, Prix = 1000000, AnneeProduction = 2020, Type = "Jet" });

// Lier les enfants aux parents
foreach (var enfant in Enfants)
{
    // Trouver le parent correspondant
    var parent = Parents.FirstOrDefault(p => p.Id == enfant.IdParent);

    // Vérifier si le parent a été trouvé
    if (parent != null)
    {
        // Ajouter l'enfant à la liste du parent
        parent.Enfants.Add(enfant);
    }
}

// Lier les parents aux enfants
foreach (var parent in Parents)
{
    // Trouver les enfants correspondants
    var enfantsDuParent = Enfants.Where(e => e.IdParent == parent.Id).ToList();

    // Affecter la liste d'enfants au parent
    parent.Enfants.AddRange(enfantsDuParent);
}

           
            // Lier les enfants aux parents
            foreach (var enfant in Enfants)
            {
                // Trouver le parent correspondant
                var parent = Parents.FirstOrDefault(p => p.Id == enfant.IdParent);

                // Vérifier si le parent a été trouvé
                if (parent != null)
                {
                    // Ajouter l'enfant à la liste du parent
                    parent.Enfants.Add(enfant);
                }
            }

            // Lier les parents aux enfants
            foreach (var parent in Parents)
            {
                // Trouver les enfants correspondants
                var enfantsDuParent = Enfants.Where(e => e.IdParent == parent.Id).ToList();

                // Affecter la liste d'enfants au parent
                parent.Enfants.AddRange(enfantsDuParent);
            }
        }
    }
}





