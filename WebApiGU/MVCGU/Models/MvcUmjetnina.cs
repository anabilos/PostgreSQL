using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCGU.Models
{
    public class MvcUmjetnina
    {
        [Display(Name = "Broj umjetnine")]
        public int idUmjetnina { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Opis { get; set; }
        public int Godina { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Slika { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Dimenzije { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Cijena { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [Display(Name = "Tip umjetnine")]
        public int idTip { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [Display(Name = "Umjetnik")]
        public int idUmjetnik { get; set; }
    }
}