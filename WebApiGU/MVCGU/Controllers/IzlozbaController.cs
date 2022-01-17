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
    public class IzlozbaController : Controller
    {
        // GET: Izlozba
        readonly string Baseurl = "https://localhost:44349/api/izlozba/";
        readonly HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<MvcIzlozba> modelList = new List<MvcIzlozba>();
            HttpResponseMessage response = client.GetAsync(Baseurl + "getallizlozba").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<MvcIzlozba>>(data);
            }
            else
            {
                ViewBag.ErrorMessage = "Dogodila se greška.";
            }
            return View(modelList);
        }

        public ActionResult AddOrEdit(int idIzložba = 0)
        {
            if (idIzložba== 0)
            {
                return View(new MvcIzlozba());
            }
            else
            {
                HttpResponseMessage response = client.GetAsync(Baseurl + "getizlozbabyid/" + idIzložba.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcIzlozba>().Result);
            }
        }
        
        [HttpPost]
        public ActionResult AddOrEdit(MvcIzlozba model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            try
            {
                if (model.idIzložba == 0)
                {
                    HttpResponseMessage response = client.PostAsync(Baseurl + "createnewizlozba", content).Result;
                    TempData["SuccessMessage"] = "Uspješno spremljeno";
                }
                else
                {
                    HttpResponseMessage response = client.PutAsync(Baseurl + "updateizlozba", content).Result;
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
            HttpResponseMessage response = client.DeleteAsync(Baseurl + "deleteizlozbabyid/" + Id.ToString()).Result;
            TempData["SuccessMessage"] = "Uspješno izbrisan podatak";

            return RedirectToAction("Index");
        }
    }

}