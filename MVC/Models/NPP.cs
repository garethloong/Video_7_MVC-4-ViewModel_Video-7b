using MVC.Helper;

namespace MVC.Models
{
	//Domain model NPP - nastavni planovi i programi
	public class NPP:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Naziv { get; set; }
        public int AkademskaGodinaId { get; set; }
        public AkademskaGodina AkademskaGodina { get; set; }
        public int SmjerId { get; set; }
        public Smjer Smjer { get; set; }
    }
}
