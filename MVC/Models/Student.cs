using MVC.Helper;

namespace MVC.Models
{
    // Domain model Student
    public class Student : IEntity
    {
        public int Id { get; set; }
   
        public string BrojIndexa { get; set; }
        public bool IsDeleted { get; set; }

		public Korisnik Korisnik { get; set; }

		//oboje dole neophodno da bi EF formirao vezu medju tabelama, a naziv property-a sa Id-em se formira tako sto na nziv klase/tabele dodaje Id (ne ID) - ovo za vezu 1:N (1 smjer : N studenata)
		public Smjer Smjer { get; set; }
        public int SmjerId { get; set; }

		public Opstina OpstinaRodjenja { get; set; }
        public int? OpstinaRodjenjaId { get; set; }

        public Opstina OpstinaPrebivalista { get; set; }
        public int? OpstinaPrebivalistaId { get; set; }

		public int? NppId { get; set; }
		public NPP Npp { get; set; }
	}
}
