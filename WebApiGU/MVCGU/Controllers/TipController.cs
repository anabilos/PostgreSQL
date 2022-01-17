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
    public class TipController : Controller
    {
        // GET: Tip
        readonly string Baseurl = "https://localhost:44349/api/tip/";
        readonly HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            List<MvcTip> modelList = new List<MvcTip>();
            HttpResponseMessage response = client.GetAsync(Baseurl + "getalltip").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<MvcTip>>(data);
            }
            else
            {
                ViewBag.ErrorMessage = "Dogodila se greška.";
            }
            return View(modelList);
        }
        public ActionResult AddOrEdit(int idTip = 0)
        {
            if (idTip == 0)
            {
                return View(new MvcTip());
            }
            else
            {
                HttpResponseMessage response = client.GetAsync(Baseurl + "gettipbyid/" + idTip.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcTip>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcTip model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            try
            {
                if (model.idTip == 0)
                {
                    HttpResponseMessage response = client.PostAsync(Baseurl + "createnewtip", content).Result;
                    TempData["SuccessMessage"] = "Uspješno spremljeno";
                }
                else
                {
                    HttpResponseMessage response = client.PutAsync(Baseurl + "updatetip", content).Result;
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
            HttpResponseMessage response = client.DeleteAsync(Baseurl + "deletetipbyid/" + Id.ToString()).Result;
            TempData["SuccessMessage"] = "Uspješno izbrisan podatak";

            return RedirectToAction("Index");
        }

    }
}