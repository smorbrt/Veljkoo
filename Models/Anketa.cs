using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Anketa")]
    public class Anketa
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(20)]
        public string Tip {get; set;}  
        
        public List<Popunjavanje> AnketaStudent {get; set;}

        public List<Pitanja> AnketaPitanja {get; set;}

        public Profesor Profesor {get; set;}

        public Zurka Zurka {get; set;}

    }
}