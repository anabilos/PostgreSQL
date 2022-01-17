using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVCGU.Models;
using Newtonsoft.Json;

namespace MVCGU.Controllers
{
    public class UmjetnikController : Controller
    {
        // GET: Umjetnik
        readonly string Baseurl = "https://localhost:44349/api/umjetnik/";
        readonly HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<MvcUmjetnik> modelList = new List<MvcUmjetnik>();
            HttpResponseMessage response = client.GetAsync(Baseurl + "getallumjetnik").Result;
            ViewBag.listaMjesta = GetMjesta().Select(x => new SelectListItem
            {
                Value = x.idMjesto.ToString(),
                Text = x.Naziv
            });
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<MvcUmjetnik>>(data);
            }
            else
            {
                ViewBag.ErrorMessage = "Dogodila se greška.";
            }
            return View(modelList);
        }

        public ActionResult AddOrEdit(int idUmjetnik = 0)
        {
            ViewBag.listaMjesta = GetMjesta().Select(x => new SelectListItem
            {
                Value = x.idMjesto.ToString(),
                Text = x.Naziv
            });

            if (idUmjetnik == 0)
            {
               
                return View(new MvcUmjetnik());
            }
            else
            {
                HttpResponseMessage response = client.GetAsync(Baseurl + "getumjetnikbyid/" + idUmjetnik.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcUmjetnik>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcUmjetnik model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            try
            {
                if (model.idUmjetnik == 0)
                {
                    HttpResponseMessage response = client.PostAsync(Baseurl + "createnewumjetnik", content).Result;
                    TempData["SuccessMessage"] = "Uspješno spremljeno";
                }
                else
                {
                    HttpResponseMessage response = client.PutAsync(Baseurl + "updateumjetnik", content).Result;
                    TempData["SuccessMessage"] = "Uspješno promjenjeno";
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            HttpResponseMessage response = client.DeleteAsync(Baseurl + "deleteumjetnikbyid/" + Id.ToString()).Result;
            TempData["SuccessMessage"] = "Uspješno izbrisan podatak";

            return RedirectToAction("Index");
        }
      
        public List<MvcPoNazivu> GetMjesta()
        {
            HttpResponseMessage response = client.GetAsync(Baseurl + "getlistumjestaponazivu").Result;
            string data = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<MvcPoNazivu>>(data);
        }



    }
}