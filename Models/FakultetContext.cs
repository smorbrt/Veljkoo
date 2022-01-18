using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class FakultetContext : DbContext
    {
        public DbSet<Student> Studenti {get; set;}

        public DbSet<Popunjavanje> StudentiAnkete {get; set;}

        public DbSet<Anketa> Ankete {get; set;}

        public DbSet<Pitanja> Pitanja {get; set;}
        
        public DbSet<Profesor> Profesori {get; set;}
       
        public DbSet<Zurka> Zurke {get; set;}

        public FakultetContext(DbContextOptions options) : base(options)
        {

        }
    }
}