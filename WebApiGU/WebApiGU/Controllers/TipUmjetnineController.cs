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
    [RoutePrefix("api/tip")]
    public class TipUmjetnineController : ApiController
    {
        static readonly Repository repository = new Repository();

        [Route("GetAllTip")]
        public IHttpActionResult GetAllTip()
        {
            List<GetAllTipove> tipovi = repository.AllTip();
            if (tipovi == null)
            {
                return NotFound();
            }
            return Ok(tipovi);
        }
        [Route("CreateNewTip")]
        public IHttpActionResult PostNewTip(CreateTipRequest Tip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var r = repository.CreateTip(Tip);
            return Ok(r);
        }
        [HttpPut]
        [Route("UpdateTip")]
        public IHttpActionResult UpdateTip(UpdateTipRequest Tip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var r = repository.UpdateTip(Tip);
            return Ok(r);
        }

        [Route("DeleteTipById/{idTip}")]
        public IHttpActionResult DeleteTipById(int idTip)
        {
            var tip = repository.GetTip(idTip);
            if (tip == null) return NotFound();

            var r = repository.DeleteTipById(tip.idTip);
            return Ok(r);
        }


        [Route("GetTipById/{idTip}")]
        public IHttpActionResult GetTipById(int idTip)
        {
            GetTipById tip = repository.GetTip(idTip);
            if (tip.idTip == 0)
            {
                return NotFound();
            }
            return Ok(tip);
        }
    }
}
