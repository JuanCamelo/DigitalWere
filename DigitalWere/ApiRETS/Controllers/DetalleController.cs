using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRETS.Controllers
{
    public class DetalleController : ApiController
    {
        FachadaNegocio Fnegocio = new FachadaNegocio();
        public IHttpActionResult Get()
        {
            List<Detalle> LstDetalle = null;
            Fnegocio = new FachadaNegocio();
            try
            {
                LstDetalle = Fnegocio.ListDetalle();

                if (LstDetalle == null)
                {
                    return NotFound();
                }

                return Ok(LstDetalle);
            }
            catch (Exception Ex)
            {
                return InternalServerError(Ex);
            }
        }

        public IHttpActionResult Post(Detalle ObjDetalle)
        {
            if (!ModelState.IsValid)
                return BadRequest("Modelo Invalido");

            Fnegocio = new FachadaNegocio();

            try
            {
                if (Fnegocio.AddDetalle(ObjDetalle))
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception Ex)
            {
                return InternalServerError(Ex);
            }
        }
    }
}
