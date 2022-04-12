using System;
using MVC.Helper;

namespace MVC.Models
{
    // Domain model SlusaPredmet
    public class SlusaPredmet:IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public int PredajeId { get; set; }
        public Predaje Predaje { get; set; }

        public int UpisGodineId { get; set; }
        public UpisGodine UpisGodine { get; set; }

        public int? FinalnaOcjena { get; set; }
        public DateTime? DatumOcjene { get; set; }

        public bool Priznato { get; set; }
    }
}
