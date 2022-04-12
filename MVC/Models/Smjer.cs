using MVC.Helper;

namespace MVC.Models
{
    // Domain model Smjer
    public class Smjer:IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Naziv { get; set; }

		//oboje dole neophodno da bi EF formirao vezu medju tabelama, a naziv property-a sa Id-em se formira tako sto na nziv klase/tabele dodaje Id (ne ID)
		public Fakultet Fakultet { get; set; }
        public int FakultetId { get; set; }
    }
}
