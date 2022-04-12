using System;
using MVC.Helper;

namespace MVC.Models
{
    // Domain model UpisGodine
    public class UpisGodine:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DatumUpisa { get; set; }
		public int GodinaStudija { get; set; }

		//oboje dole neophodno da bi EF formirao vezu medju tabelama, a naziv property-a sa Id-em se formira tako sto na nziv klase/tabele dodaje Id (ne ID)
		//Ako polje Student kod upisa godine teoretski nije obavezno, mozemo staviti da je tipa int? umjesto int
		public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int AkademskaGodinaId { get; set; }
        public virtual AkademskaGodina AkademskaGodina { get; set; }
		
	}
}
