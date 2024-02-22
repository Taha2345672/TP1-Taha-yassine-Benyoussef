using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Models
{

    public class Enfant
    {
        [Key]
        public int EnfantId { get; set; }

        [Display(Name = "Nom de l'enfant")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le nom doit avoir entre 2 et 50 caractères.")]
        public string Nom { get; set; }

        [Display(Name = "Description de l'enfant")]
        [StringLength(200, ErrorMessage = "La description ne peut pas dépasser 200 caractères.")]
        public string Description { get; set; }

        [Display(Name = "Nom du fichier image")]
        public string ImageFileName { get; set; }

        [ForeignKey("Parent")]
        public int IdParent { get; set; }
        [ValidateNever]
        public Parent? Parent { get; set; }

        [Display(Name = "Prix de l'enfant")]
        [Range(0, double.MaxValue, ErrorMessage = "Le prix doit être un nombre positif.")]
        public decimal Prix { get; set; }

        [Display(Name = "Année de production de l'enfant")]
        [Range(1800, 2100, ErrorMessage = "L'année de production doit être entre 1800 et 2100.")]
        public int AnneeProduction { get; set; }

        [Display(Name = "Type de l'enfant")]
        public string? Type { get; set; }




    }


}
