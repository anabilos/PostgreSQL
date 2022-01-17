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
    [RoutePrefix("api/umjetnina")]
    public class UmjetninaController : ApiController
    {
        static readonly Repository repository = new Repository();

        [Route("GetAllUmjetnina")]
        public IHttpActionResult GetAllUmjetnina()
        {
            List<GetAllUmjetnine> umjetnine = repository.AllUmjetnina();
            if (umjetnine == null)
            {
                return NotFound();
            }
            return Ok(umjetnine);
        }

        [Route("CreateNewUmjetnina")]
        public IHttpActionResult PostNewUmjetnina(CreateUmjetninaRequest Umjetnina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var r = repository.CreateUmjetnina(Umjetnina);
            return Ok(r);
        }
        [HttpPut]
        [Route("UpdateUmjetnina")]
        public IHttpActionResult UpdateUmjetnina(UpdateUmjetninaRequest Umjetnina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var r = repository.UpdateUmjetnina(Umjetnina);
            return Ok(r);
        }

        [Route("DeleteUmjetninaById/{idUmjetnina}")]
        public IHttpActionResult DeleteUmjetninaById(int idUmjetnina)
        {
            var umjetnina = repository.GetUmjetnina(idUmjetnina);
            if (umjetnina == null) return NotFound();

            var r = repository.DeleteUmjetninaById(umjetnina.idUmjetnina);
            return Ok(r);
        }

        [Route("GetUmjetninaById/{idUmjetnina}")]
        public IHttpActionResult GetUmjetninaById(int idUmjetnina)
        {
            GetUmjetninaById umjetnina = repository.GetUmjetnina(idUmjetnina);
            if (umjetnina.idUmjetnina == 0)
            {
                return NotFound();
            }
            return Ok(umjetnina);
        }

        [Route("GetListuTipovaPoNazivu")]
        public IHttpActionResult GetListuTipovaPoNazivu()
        {
            List<GetListuTipovaPoNazivu> tipovi = repository.AllTipova();
            if (tipovi == null)
            {
                return NotFound();
            }
            return Ok(tipovi);
        }

        [Route("GetListuUmjetnikaPoNazivu")]
        public IHttpActionResult GetListuUmjetnikaPoNazivu()
        {
            List<GetListuUmjetnikaPoNazivu> umjetnici = repository.AllUmjetnika();
            if (umjetnici == null)
            {
                return NotFound();
            }
            return Ok(umjetnici);
        }
    }
}
