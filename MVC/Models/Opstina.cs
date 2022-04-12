using MVC.Helper;

namespace MVC.Models
{
    // Domain model Opstina
    public class Opstina:IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Opis { get; set; }

        public int RegijaId { get; set; }
        public Regija Regija { get; set; }
    }
}
