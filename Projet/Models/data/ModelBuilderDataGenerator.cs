using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Parent>().HasData(
            
                new Parent() { ParentId = 1, Nom = "CESSNA", ImageFileName = "CESSNA.png", Description = "Description du CESSNA"  },
                new Parent() {  ParentId  = 2, Nom = "PIPER", ImageFileName = "PIPER.png", Description = "Description du PIPER" } ,
                new Parent() {  ParentId  = 3, Nom = "CIRRUS", ImageFileName = "CIRRUS.png", Description = "Description du CIRRUS" }
            );

            modelBuilder.Entity<Enfant>().HasData(
            
                new Enfant { EnfantId = 1, Nom = "Cessna 172", Description = "Avion monomoteur léger.", ImageFileName = "cessna 172 1.png", IdParent = 1, Prix = 100000, AnneeProduction = 2005, Type = "Monomoteur" },
                new Enfant { EnfantId =  2, Nom = "Cessna 152", Description = "Avion monomoteur léger.", ImageFileName = "cessna 152 2.png", IdParent = 1, Prix = 80000, AnneeProduction = 2002, Type = "Monomoteur" },
                new Enfant { EnfantId =  3, Nom = "Cessna 182", Description = "Avion monomoteur à pistons.", ImageFileName = "CESSNA 182 1.png", IdParent = 1, Prix = 120000, AnneeProduction = 2008, Type = "Monomoteur" },
                new Enfant { EnfantId = 4, Nom = "Cessna Citation", Description = "Jet d'affaires léger à réaction.", ImageFileName = "Carravan.png", IdParent = 1, Prix = 500000, AnneeProduction = 2015, Type = "Jet" },


                new Enfant {EnfantId =  5, Nom = "Piper Archer", Description = "Avion léger à quatre places.", ImageFileName = "Archer 1.png", IdParent = 2, Prix = 90000, AnneeProduction = 2010, Type = "Léger" },
                new Enfant { EnfantId =  6, Nom = "Piper Cherokee", Description = "Avion monomoteur à ailes hautes.", ImageFileName = "CHEROKEE 1.png", IdParent = 2, Prix = 75000, AnneeProduction = 2007, Type = "Monomoteur" },
                new Enfant { EnfantId =  7, Nom = "Piper PA24", Description = "Avion léger de sport.", ImageFileName = "PIPER PA24.png", IdParent = 2, Prix = 80000, AnneeProduction = 2009, Type = "Léger" },
                new Enfant { EnfantId =  8, Nom = "Piper PA28", Description = "Avion monomoteur léger et rapide.", ImageFileName = "piper pa28.png", IdParent = 2, Prix = 100000, AnneeProduction = 2012, Type = "Monomoteur" },

                new Enfant {EnfantId =  9, Nom = "Cirrus SR22T", Description = "Jet d'affaires monoréacteur.", ImageFileName = "SR22T 1.png", IdParent = 3, Prix = 600000, AnneeProduction = 2018, Type = "Jet" },
                new Enfant { EnfantId = 10, Nom = "Cirrus SR22", Description = "Avion monomoteur à pistons de haute performance.", ImageFileName = "SR22 1.png", IdParent = 3, Prix = 300000, AnneeProduction = 2015, Type = "Monomoteur" },
                new Enfant { EnfantId =  11, Nom = "Cirrus SR20", Description = "Avion à réaction légère.", ImageFileName = "SR20 1.png", IdParent = 3, Prix = 200000, AnneeProduction = 2013, Type = "Monomoteur" },
                new Enfant { EnfantId =  12, Nom = "Cirrus Vision Jet", Description = "Jet monomoteur à réaction de type Vision Jet.", ImageFileName = "VISON JET 1.png", IdParent = 3, Prix = 1000000, AnneeProduction = 2020, Type = "Jet" }
            );

            
           
        }
    }
}
