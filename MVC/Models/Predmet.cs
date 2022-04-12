using MVC.Helper;

namespace MVC.Models
{
    // Domain model Predmet
    public class Predmet : IEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Naziv { get; set; }

        public float Ects { get; set; }

        public int NppId { get; set; }
        public NPP Npp { get; set; }
		public int GodinaStudija { get; set; }
	}
}
