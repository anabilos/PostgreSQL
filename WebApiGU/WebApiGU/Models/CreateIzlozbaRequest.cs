using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiGU.Models
{
    public class CreateIzlozbaRequest
    {
        public int idIzložba { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum_završetka { get; set; }
        public DateTime Datum_početka { get; set; }
        public string Prostor_održavanja{ get; set; }
    }
}