using MVC.Helper;

namespace MVC.Models
{
    // Domain model Referent
    public class Referent : IEntity
    {
        public int Id { get; set; }
   
    
        public bool IsDeleted { get; set; }

        public Korisnik Korisnik { get; set; }

	}
}
