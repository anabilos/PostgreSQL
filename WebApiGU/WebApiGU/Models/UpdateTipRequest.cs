using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiGU.Models
{
    public class UpdateTipRequest
    {
        public int idTip { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}