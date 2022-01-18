using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Zurka")]
    public class Zurka
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(200)]
        public string Lokacija {get; set;}

        [MaxLength(100)]
        public string Sati {get; set;}

        [MaxLength(100)]
        public string Zanrovi {get; set;}

        public List<Anketa> ZurkaAnketa {get; set;}

        //opciono u kojem amfiju predaje




    }
}