using MVC.DAL;
using MVC.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Areas.ModulStudentskaSluzba.Data;

namespace MVC.Areas.ModulStudentskaSluzba.Controllers
{
    public class StudentController : Controller
    {
        MyContext mc = new MyContext();

        // defaultna akcija (kada unesemo samo http://localhost:50913/Student/)
        public ActionResult Index()
        {
            return View("Index");
        }

        // pristupamo sa: http://localhost:50913/Student/Prikazi)
        public ActionResult Prikazi(int? smjerId)   // mozemo prikazati sve studente bez zadavanja smjera (null)
        {
            StudentPrikaziViewModel Model = new StudentPrikaziViewModel();

            Model.studenti = mc.Studenti
              .Where(x => !smjerId.HasValue || x.SmjerId == smjerId)     // ako smjerId nema vrijednost (ako je null), drugi uslov se nece ni gledati, pa ce vratiti sve studente
              .Select(x => new StudentPrikaziViewModel.StudenInfo()
              {
                  // Student = x,     // kako u ViewModelu vise ne koristimo domain model tipa Student nego njegove atribute, iste je potrebno inicijalizovat
                  BrojIndexa = x.BrojIndexa,
                  Fakultet_Naziv = x.Smjer.Fakultet.Naziv,
                  Id = x.Id,
                  Ime = x.Korisnik.Ime,
                  Prezime = x.Korisnik.Prezime,
                  Smjer_Naziv = x.Smjer.Naziv,

                  ECTSukupno = mc.SlusaPredmete.Where(y => y.UpisGodine.StudentId == x.Id && y.FinalnaOcjena > 5).Sum(z => (float?) z.Predaje.Predmet.Ects) ?? 0, // float? jer moze da ne vrati nista (npr. ECTS nije unesen)
                  BrojPolozenihPredmeta = mc.SlusaPredmete.Where(y => y.UpisGodine.StudentId == x.Id && y.FinalnaOcjena > 5).Count()
              })
                .ToList();

            ////////////////////////////////

            Model.smjeroviStavke = new List<SelectListItem>();
            Model.smjeroviStavke.Add(new SelectListItem { Value = null, Text = "Svi smjerovi" });
            Model.smjeroviStavke.AddRange(mc.Smjerovi.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Fakultet.Naziv + " " + x.Naziv }).ToList());

            return View("Prikazi", Model);
        }

        public ActionResult Obrisi(int studentId)
        {
            Student s = mc.Studenti.Where(x => x.Id == studentId).Include(x => x.Korisnik).FirstOrDefault();
            mc.Studenti.Remove(s);
            mc.SaveChanges();

            return RedirectToAction("Prikazi");
        }

        //  http://localhost:50913/Student/Dodaj
        public ActionResult Dodaj()
        {
            Student s = new Student();
            s.Korisnik = new Korisnik();
            ViewData["student"] = s;

            List<Smjer> smjerovi = mc.Smjerovi
                .Include(x => x.Fakultet)
                .ToList();
            ViewData["smjerovi"] = smjerovi;

            return View("Uredi");
        }

        public ActionResult Uredi(int studentId)
        {
            // Student student = mc.Studenti.Find(studentId);   // Korisnik objekat se ne nalazi u objektu student
            Student student = mc.Studenti.Where(x => x.Id == studentId).Include(x => x.Korisnik).FirstOrDefault();      // Include() ne radi sa Find() pa moramo koristiti Where()

            ViewData["student"] = student;

            List<Smjer> smjerovi = mc.Smjerovi
              .Include(x => x.Fakultet)
              .ToList();
            ViewData["smjerovi"] = smjerovi;

            return View("Uredi");
        }

        public ActionResult Snimi(int? studentId, string ime, string prezime, string brojindexa, string username, string password, DateTime datumRodjenja, int smjerId)
        {
            Student s;

            if (studentId == null || studentId == 0)
            {
                s = new Student();
                s.Korisnik = new Korisnik();
                mc.Studenti.Add(s);     // Mozemo prvo dodati objekat pa ga onda setovat i obrnuto - redoslijed nije bitan (objekat se nalazi u memoriji)
            }
            else
            {
                s = mc.Studenti.Where(x => x.Id == studentId).Include(x => x.Korisnik).FirstOrDefault();
            }

            // setovanje objekta
            s.Korisnik.Ime = ime;
            s.Korisnik.Prezime = prezime;
            s.Korisnik.Username = username;
            s.Korisnik.Password = password;
            s.Korisnik.DatumRodjenja = datumRodjenja;
            s.BrojIndexa = brojindexa;
            s.SmjerId = smjerId;

            mc.SaveChanges();   // snima objekat u bazu

            return RedirectToAction("Prikazi");
        }





    }
}