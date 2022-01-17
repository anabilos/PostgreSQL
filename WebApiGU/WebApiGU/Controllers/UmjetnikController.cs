using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiGU.Data;
using WebApiGU.Models;

namespace WebApiGU.Controllers
{
    [RoutePrefix("api/umjetnik")]
    public class UmjetnikController : ApiController
    {
        static readonly Repository repository = new Repository();

        [Route("GetAllUmjetnik")]
        public IHttpActionResult GetAllUmjetnik()
        {
            List<GetAllUmjetnike> umjetnici = repository.AllUmjetnik();
            if (umjetnici == null)
            {
                return NotFound();
            }
            return Ok(umjetnici);
        }
        [Route("CreateNewUmjetnik")]
        public IHttpActionResult PostNewUmjetnik(CreateUmjetnikRequest Umjetnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var r = repository.CreateUmjetnik(Umjetnik);
            return Ok(r);
        }
        [HttpPut]
        [Route("UpdateUmjetnik")]
        public IHttpActionResult UpdateUmjetnik(UpdateUmjetnikRequest Umjetnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var r = repository.UpdateUmjetnik(Umjetnik);
            return Ok(r);
        }
        [Route("DeleteUmjetnikById/{idUmjetnik}")]
        public IHttpActionResult DeleteUmjetnikById(int idUmjetnik)
        {
            var umjetnik = repository.GetUmjetnik(idUmjetnik);
            if (umjetnik == null) return NotFound();

            var r = repository.DeleteUmjetnikById(umjetnik.idUmjetnik);
            return Ok(r);
        }

        [Route("GetUmjetnikById/{idUmjetnik}")]
        public IHttpActionResult GetUmjetnikById(int idUmjetnik)
        {
            GetUmjetnikById umjetnik = repository.GetUmjetnik(idUmjetnik);
            if (umjetnik.idUmjetnik == 0)
            {
                return NotFound();
            }
            return Ok(umjetnik);
        }
        [Route("GetListuMjestaPoNazivu")]
        public IHttpActionResult GetListuMjestaPoNazivu()
        {
            List<GetListuMjestaPoNazivu> mjesta = repository.AllMjesta();
            if (mjesta == null)
            {
                return NotFound();
            }
            return Ok(mjesta);
        }
    }
}
