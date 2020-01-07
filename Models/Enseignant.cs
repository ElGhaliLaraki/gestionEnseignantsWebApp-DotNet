using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace gestionEnseignantsWebApp.Models{
    [Table("ENSEIGNANTS")]
    public class Enseignant{
        [Key]
        public int EnseignantID { get; set; }
        public string Name { get; set; }
        public int DepartementID {get;set;}
        [ForeignKey("DepartementID")]

        public virtual Departement Departement{get; set;}
    }
}