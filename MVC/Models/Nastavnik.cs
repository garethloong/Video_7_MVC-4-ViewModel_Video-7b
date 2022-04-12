using MVC.Helper;

namespace MVC.Models
{
    // Domain model Nastavnik
    public class Nastavnik : IEntity
    {
        public int Id { get; set; }
   
    
        public bool IsDeleted { get; set; }

        public string titula { get; set; }

        public Korisnik Korisnik { get; set; }
    }
}
