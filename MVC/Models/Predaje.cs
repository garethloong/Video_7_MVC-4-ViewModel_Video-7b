using MVC.Helper;

namespace MVC.Models
{
    // Domain model Predaje
    public class Predaje : IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public int NastavnikId { get; set; }
        public Nastavnik Nastavnik { get; set; }

        public int AkademskaGodinaId { get; set; }
        public AkademskaGodina AkademskaGodina { get; set; }

        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }
    }
}
