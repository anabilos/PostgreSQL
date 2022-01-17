using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiGU.Models
{
    public class GetTipById
    {
        public int idTip { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}