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
    public class UmjetninaController : Controller
    {
        // GET: Umjetnina
        readonly string Baseurl = "https://localhost:44349/api/umjetnina/";
        readonly HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<MvcUmjetnina> modelList = new List<MvcUmjetnina>();
            HttpResponseMessage response = client.GetAsync(Baseurl + "getallumjetnina").Result;
            ViewBag.listaUmjetnika = GetUmjetnike().Select(x => new SelectListItem
            {
                Value = x.idUmjetnik.ToString(),
                Text = x.Naziv
            });
            ViewBag.listaTipova = GetTipove().Select(x => new SelectListItem
            {
                Value = x.idTip.ToString(),
                Text = x.Naziv
            });
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<MvcUmjetnina>>(data);
            }
            else
            {
                ViewBag.ErrorMessage = "Dogodila se greška.";
            }
            return View(modelList);
        }
        public ActionResult AddOrEdit(int idUmjetnina = 0)
        {
            ViewBag.listaUmjetnika= GetUmjetnike().Select(x => new SelectListItem
            {
                Value = x.idUmjetnik.ToString(),
                Text = x.Naziv
            });
            ViewBag.listaTipova = GetTipove().Select(x => new SelectListItem
            {
                Value = x.idTip.ToString(),
                Text = x.Naziv
            });
            if (idUmjetnina == 0)
            {

                return View(new MvcUmjetnina());
            }
            else
            {
                HttpResponseMessage response = client.GetAsync(Baseurl + "GetUmjetninaById/" + idUmjetnina.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcUmjetnina>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcUmjetnina model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            try
            {
                if (model.idUmjetnina == 0)
                {
                    HttpResponseMessage response = client.PostAsync(Baseurl + "createnewumjetnina", content).Result;
                    TempData["SuccessMessage"] = "Uspješno spremljeno";
                }
                else
                {
                    HttpResponseMessage response = client.PutAsync(Baseurl + "updateumjetnina", content).Result;
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
            HttpResponseMessage response = client.DeleteAsync(Baseurl + "deleteumjetninabyid/" + Id.ToString()).Result;
            TempData["SuccessMessage"] = "Uspješno izbrisan podatak";

            return RedirectToAction("Index");
        }
        public List<MvcPoNazivuU> GetUmjetnike()
        {
            HttpResponseMessage response = client.GetAsync(Baseurl + "getlistuumjetnikaponazivu").Result;
            string data = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<MvcPoNazivuU>>(data);
        }
        public List<MvcPoNazivuT> GetTipove()
        {
            HttpResponseMessage response = client.GetAsync(Baseurl + "getlistutipovaponazivu").Result;
            string data = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<MvcPoNazivuT>>(data);
        }

    }
}