using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCGU.Models
{
    public class MvcUmjetnik
    {
        public int idUmjetnik { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum rođenja")]
        public DateTime Datum_rođenja { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [Display(Name = "Broj mjesta")]
        public int idMjesto { get; set; }
       
    }
}