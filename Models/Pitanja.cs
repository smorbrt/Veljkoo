using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Pitanja")]
    public class Pitanja
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(666)]
        public string ListaPitanja {get; set;}   //tip ankete
        
        public List<Anketa> PitanjaAnketa {get; set;}



    }
}