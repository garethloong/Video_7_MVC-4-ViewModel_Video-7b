using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Areas.ModulStudentskaSluzba.Data
{
    // ViewModel za View Prikazi unutar foldera Student, unutar Area-a ModulStudentskaSluzba
    public class StudentPrikaziViewModel
    {
        // nested class StudentInfo
        public class StudenInfo
        {
            public float? ECTSukupno { get; set; }
            public int? BrojPolozenihPredmeta { get; set; }
            // public Student Student { get; set; }
            // Student se razlaze na donje atribute
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string BrojIndexa { get; set; }
            public string Fakultet_Naziv { get; set; }
            public string Smjer_Naziv { get; set; }
        }

        public List<StudenInfo> studenti;

        // Smjer Id and the list are needed in order to populate drop down
        public int SmjerId { get; set; }
        public List<SelectListItem> smjeroviStavke { get; set; }
    }
}