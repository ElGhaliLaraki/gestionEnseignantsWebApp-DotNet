using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace gestionEnseignantsWebApp.Models{
    [Table("DEPARTEMENTS")]
    public class Departement{
        [Key]
        public int DepartementID { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection <Enseignant> Enseignants { get; set; }
    }
}