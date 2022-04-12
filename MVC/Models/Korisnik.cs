using System;
using MVC.Helper;

namespace MVC.Models
{
    // Domain model Korisnik
    public class Korisnik:IEntity
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public DateTime? DatumRodjenja { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public Student Student { get; set; }
        public Nastavnik Nastavnik { get; set; }
        public Referent Referent { get; set; }
		public Administrator Administrator { get; set; }
		public string ImeIPrezime { get { return Ime + " " + Prezime; } }
    }
}
