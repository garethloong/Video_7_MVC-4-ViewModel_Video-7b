using MVC.Helper;

namespace MVC.Models
{
    // Domain model Regija
    public class Regija:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Naziv { get; set; }
    }
}
