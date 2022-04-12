using MVC.Helper;

namespace MVC.Models
{
    // Domain model AkademskaGodina
    public class AkademskaGodina:IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Opis { get; set; }
       
    }
}
