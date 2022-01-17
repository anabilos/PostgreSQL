using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiGU.Models
{
    public class GetUmjetnikById
    {
        public int idUmjetnik { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public DateTime Datum_rođenja { get; set; }
        public int idMjesto { get; set; }
    }
}