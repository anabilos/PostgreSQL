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
    [RoutePrefix("api/izlozba")]
    public class IzlozbaController : ApiController
    {
        static readonly Repository repository = new Repository();

        [Route("CreateNewIzlozba")]
        public IHttpActionResult PostNewIzlozba(CreateIzlozbaRequest Izlozba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var r = repository.CreateIzlozba(Izlozba);
            return Ok(r);
        }

        [Route("GetAllIzlozba")]
        public IHttpActionResult GetAllIzlozba()
        {
            List<GetAllIzlozbe> izlozbe = repository.AllIzlozba();
            if (izlozbe == null)
            {
                return NotFound();
            }
            return Ok(izlozbe);
        }

        [Route("DeleteIzlozbaById/{idIzložba}")]
        public IHttpActionResult DeleteIzlozbaById(int idIzložba)
        {
            var izlozba = repository.GetIzlozba(idIzložba);
            if (izlozba == null) return NotFound();

            var r = repository.DeleteIzlozbaById(izlozba.idIzložba);
            return Ok(r);
        }

        [Route("GetIzlozbaById/{idIzložba}")]
        public IHttpActionResult GetIzlozbaById(int idIzložba)
        {
            GetIzlozbaById izlozba = repository.GetIzlozba(idIzložba);
            if (izlozba.idIzložba == 0)
            {
                return NotFound();
            }
            return Ok(izlozba);
        }
        [HttpPut]
        [Route("UpdateIzlozba")]
        public IHttpActionResult UpdateIzlozba(UpdateIzlozbaRequest Izlozba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var r = repository.UpdateIzlozba(Izlozba);
            return Ok(r);
        }
    }
}
