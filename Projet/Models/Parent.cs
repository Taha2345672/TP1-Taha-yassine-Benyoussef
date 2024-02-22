using System.Collections.Generic;

namespace Projet.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }

        public List<Enfant> Enfants { get; set; } = new List<Enfant>();


    }
}