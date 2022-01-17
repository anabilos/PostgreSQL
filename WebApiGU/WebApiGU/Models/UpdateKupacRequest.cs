using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiGU.Models
{
    public class UpdateKupacRequest
    {
        public int idKupac { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Broj_telefona { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
    }
}