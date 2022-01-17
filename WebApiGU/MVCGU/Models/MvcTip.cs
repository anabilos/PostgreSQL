using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCGU.Models
{
    public class MvcTip
    {
        [Display(Name = "Broj")]
        public int idTip { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Opis{ get; set; }
     
    }
}