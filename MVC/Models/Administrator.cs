using MVC.Helper;

namespace MVC.Models
{
	// Domain model Administrator
	public class Administrator : IEntity
    {
		public int Id { get; set; }


		public bool IsDeleted { get; set; }

		public Korisnik Korisnik { get; set; }
	}
}
