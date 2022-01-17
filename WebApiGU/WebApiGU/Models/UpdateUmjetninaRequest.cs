using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiGU.Models
{
    public class UpdateUmjetninaRequest
    {
        public int idUmjetnina { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int Godina { get; set; }
        public string Slika { get; set; }
        public string Dimenzije { get; set; }
        public string Cijena { get; set; }
        public int idTip { get; set; }
        public int idUmjetnik { get; set; }
    }
}