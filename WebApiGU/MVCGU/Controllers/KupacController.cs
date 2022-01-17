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
    public class KupacController : Controller
    {
        // GET: Kupac
        readonly string Baseurl = "https://localhost:44349/api/kupac/";
        readonly HttpClient client = new HttpClient();

      
        public ActionResult Index()
        {
            List<MvcKupac> modelList = new List<MvcKupac>();
            HttpResponseMessage response = client.GetAsync(Baseurl + "getallkupac").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<MvcKupac>>(data);
            }
            else
            {
                ViewBag.ErrorMessage = "Dogodila se greška.";
            }
            return View(modelList);
        }

        public ActionResult AddOrEdit(int idKupac = 0)
        {
            if (idKupac == 0)
            {
                return View(new MvcKupac());
            }
            else
            {
                HttpResponseMessage response = client.GetAsync(Baseurl + "getkupacbyid/" + idKupac.ToString()).Result;              
                return View(response.Content.ReadAsAsync<MvcKupac>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcKupac model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            try
            {
                if (model.idKupac == 0)
                {
                    HttpResponseMessage response = client.PostAsync(Baseurl + "createnewkupac", content).Result;
                    TempData["SuccessMessage"] = "Uspješno spremljeno";
                }
                else
                {
                    HttpResponseMessage response = client.PutAsync(Baseurl + "updatekupac", content).Result;
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
            HttpResponseMessage response = client.DeleteAsync(Baseurl + "deletekupacbyid/" + Id.ToString()).Result;
            TempData["SuccessMessage"] = "Uspješno izbrisan podatak";

            return RedirectToAction("Index");
        }
    }
}