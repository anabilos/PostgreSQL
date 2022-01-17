using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCGU.Models
{
    public class MvcIzlozba
    {
        public int idIzložba{ get; set; }
        [Display(Name = "Naziv")]
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Naziv { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum početka")]
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public DateTime Datum_početka { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum završetka")]
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public DateTime Datum_završetka { get; set; }

        [Display(Name = "Prostor održavanja")]
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Prostor_održavanja { get; set; }
       
    }
}