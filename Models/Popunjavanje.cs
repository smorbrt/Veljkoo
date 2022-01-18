using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Popunjavanje")]
    public class Popunjavanje  //bukvalno Spoj
    {
        [Key]
        public int ID { get; set; }

        public bool Popunio {get; set;}

        public Student Student {get; set;} 
                                             //ove dve linije mi prave vezu Student:Anketa = N:M  ili List<Student> List<Anketa>
        public Anketa Anketa {get; set;}

        
        



    }
}