using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCGU.Models
{
    public class MvcKupac
    {
        public int idKupac{ get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [Display(Name ="Telefon")]
        public string Broj_telefona { get; set; }
     
    }
}