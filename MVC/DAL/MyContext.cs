using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.DAL
{
    class MyContext : DbContext
    {
        public MyContext() : base("MyConnectionString")
        {

        }

        // Slicno kao VirtualDB u prethodnom videu, s tim da nije potrebno inicijalizirat ove propertije u konstruktoru - to radi klasa MyContext koja je naslijedila DbContext.
        public DbSet<Administrator> Administratori { set; get; }
        public DbSet<Student> Studenti { set; get; }
        public DbSet<Fakultet> Fakulteti { set; get; }
        public DbSet<Smjer> Smjerovi { set; get; }
        public DbSet<AkademskaGodina> AkademskeGodine { set; get; }
        public DbSet<UpisGodine> UpisiGodine { set; get; }
        public DbSet<Referent> Referenti { set; get; }
        public DbSet<Nastavnik> Nastavnici { set; get; }
        public DbSet<Korisnik> Korisnici { set; get; }
        public DbSet<Predaje> Predaje { set; get; }
        public DbSet<Predmet> Predmeti { set; get; }
        public DbSet<NPP> NPPs { set; get; }
        public DbSet<Regija> Regije { set; get; }
        public DbSet<Opstina> Opstine { set; get; }
        public DbSet<SlusaPredmet> SlusaPredmete { set; get; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Npr.Potrebno je omoguciti da Student moze promijeniti Smjer kod UpisaGodine, tako sto cemo povezati Studenta i Smjer. Bez donje linije to nece biti moguce zbog toga sto ce u tom slucaju Smjer sa Studentom
            // biti povezan vezom 1:N, bas kao i sa UpisomGodine(1:N) pa imamo slucaj visestruke kaskade(vise putanja). Donja linija koda potpuno uklanja kaskadu na Delete / Update.Dakle ako Student promijeni smjer, to
            // treba da se updateuje ne samo u tabeli UpisGodine nego i u tabeli Student(i obrnuto ako se promjena prvo dogodi u tabeli Student treba da se isto provede i na tabelu UpisGodine).
            
            // Removes cascades on delete. Requires System.Data.Entity.ModelConfiguration.Conventions namespace.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // u EF 1:1 veze nisu automatski prepoznate, pa je to potrebno objasniti u OnModelCreating() funkciji u MyDBContext
            // Donje linije koda omogucavaju 1:1 veze npr. ako imamo superklasu/tabelu Korisnik i podklase/tabele Student, Nastavnik, Referent. 
            // Ovo je kroz Fluent API, a moglo je ovo isto da se uradi u klasama sa Data Anotations sa [Required] ili navodjenjem .

            // one-to-(zero or one)
            modelBuilder.Entity<Korisnik>().HasOptional(x => x.Student).WithRequired(x => x.Korisnik);  // Korisnik ima opcionalnu vezu prema entitetu Student, a Student ima obaveznu vezu prema entitetu Korisnik.
            // modelBuilder.Entity<Student>().HasRequired(x => x.Korisnik).WithOptional(x => x.Student);	// isto sto i prethodna linija
            modelBuilder.Entity<Korisnik>().HasOptional(x => x.Nastavnik).WithRequired(x => x.Korisnik);
            modelBuilder.Entity<Korisnik>().HasOptional(x => x.Referent).WithRequired(x => x.Korisnik);
            modelBuilder.Entity<Korisnik>().HasOptional(x => x.Administrator).WithRequired(x => x.Korisnik);


            // Ovo ce proci kod "update-database" ako je baza prazna. Medjutim ako ima podataka, to nece raditi jer za Studenta koji je vec u bazi, ne bi postojao odgovarajuci rekord u tabeli Korisnik a rekli smo da Student zahtijeva da ima 
            // rekord u tabeli Korisnik, dok je obrnuto opcionalno.
            // Ukoliko npr. zelimo da obrisemo jednu kolonu u tabeli (atribut entiteta) a u bazi postoje podaci u toj koloni, onda to mozemo da uradimo sa "update-database -Force".
            // Ako zelimo da uklonimo oznaku Identity sa neke kolone, onda moramo uraiti izmjenu u InitialCreate migraciji, a zatim obrisati bazu, te izvrsiti program koji ce onda kreirati novu bazu.


            // many-to-one
            // modelBuilder.Entity<Smjer>().HasRequired(x => x.Fakultet).WithMany().HasForeignKey(x=>x.FakultetId);
            // modelBuilder.Entity<UpisGodine>().HasRequired(x => x.Student).WithMany().HasForeignKey(x=>x.StudentId);
            // modelBuilder.Entity<UpisGodine>().HasRequired(x => x.AkademskaGodina).WithMany().HasForeignKey(x=>x.AkademskaGodinaId);

            // https://msdn.microsoft.com/en-us/library/jj591583(v=vs.113).aspx
            // http://blogs.msdn.com/b/adonet/archive/2010/12/14/ef-feature-ctp5-fluent-api-samples.aspx
        }
    }
}
