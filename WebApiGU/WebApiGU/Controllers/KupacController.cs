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
    [RoutePrefix("api/kupac")]
    public class KupacController : ApiController
    {
        static readonly Repository repository = new Repository();

        [Route("CreateNewKupac")]
        public IHttpActionResult PostNewKupac(CreateKupacRequest Kupac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var r = repository.CreateKupac(Kupac);
            return Ok(r);
        }

        [Route("GetAllKupac")]
        public IHttpActionResult GetAllKupac()
        {
            List<GetAllKupce> kupci = repository.AllKupac();
            if (kupci == null)
            {
                return NotFound();
            }
            return Ok(kupci);
        }
        [HttpPut]
        [Route("UpdateKupac")]
        public IHttpActionResult UpdateKupac(UpdateKupacRequest Kupac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var r = repository.UpdateKupac(Kupac);
            return Ok(r);
        }

        [Route("DeleteKupacById/{idKupac}")]
        public IHttpActionResult DeleteKupacById(int idKupac)
        {
            var kupac = repository.GetKupac(idKupac);
            if (kupac == null) return NotFound();

            var r = repository.DeleteKupacById(kupac.idKupac);
            return Ok(r);
        }

        [Route("GetKupacById/{idKupac}")]
        public IHttpActionResult GetKupacById(int idKupac)
        {
            GetKupacById kupac = repository.GetKupac(idKupac);
            if (kupac.idKupac == 0)
            {
                return NotFound();
            }
            return Ok(kupac);
        }
    }
}
