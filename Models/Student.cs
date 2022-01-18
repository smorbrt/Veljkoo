using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{    
    [Table("Student")] //ovako se zova tabela u bazi
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Range(10000,20000)]
        public int Indeks{get; set;}

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Ime {get; set;}

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Prezime{get; set;}

        public List<Popunjavanje> StudentAnketa {get; set;}

        /*//imam ovoliki broj kolona jer nam moze posluziti da vidimo koje predmete su studenti hteli da popune 
        public bool ENG {get; set;}

        public bool OS {get; set;}

        public bool RM {get; set;}

        public bool OOP {get; set;}

        public bool WEB{get; set;}

        //ako 
        
        [MaxLength(50)]
        public string lokacija{ get; set;}
        
        [MaxLength(15)]
        public string zanr{get; set;}

        [Range(0,23)]
        public int sati{get; set;}

        public Anketa Anketa {get; set;}*/

    }
}