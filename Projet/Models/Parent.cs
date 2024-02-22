using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class Parent

    {
        [Key] 
        public int EnfantId { get; set; }

        public int ParentId { get; set; }

        [Display(Name="Nom du parent")]
        [StringLength(50,MinimumLength =2)]
        public string Nom { get; set; }


        [Display(Name = "Description du parent")]
        [StringLength(200)]
        public string Description { get; set; }

        [Display(Name = "image du parent")]
        public string ImageFileName { get; set; }

        [ValidateNever]
        public List<Enfant> Enfants { get; set; } = new List<Enfant>();


    }
}