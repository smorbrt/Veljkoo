using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Profesor")]
    public class Profesor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Ime {get; set;}

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Prezime {get; set;}

        public string ProceneOcene {get; set;} //ipak sam se odlucio za string 

        public string Komentari {get; set;}

        public List<Anketa> ProfesorAnketa {get; set;}

        //opciono u kojem amfiju predaje




    }
}