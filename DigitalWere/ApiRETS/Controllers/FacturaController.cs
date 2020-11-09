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
    public class FacturaController : ApiController
    {
        FachadaNegocio Fnegocio = new FachadaNegocio();
        public IHttpActionResult Get()
        {
            List<Factura> LstFactura = null;
            Fnegocio = new FachadaNegocio();
            try
            {
                LstFactura = Fnegocio.ListaFactura();

                if (LstFactura == null)
                {
                    return NotFound();
                }

                return Ok(LstFactura);
            }
            catch (Exception Ex)
            {
                return InternalServerError(Ex);
            }
        }


        public IHttpActionResult Get(int Id)
        {
            Factura ObjFactura = null;
            Fnegocio = new FachadaNegocio();
            try
            {
                ObjFactura = Fnegocio.GetFacturaById(Id);

                if (ObjFactura.IdFactura == 0)
                {
                    return NotFound();
                }

                return Ok(ObjFactura);
            }
            catch (Exception Ex)
            {
                return InternalServerError(Ex);
            }
        }

        /// <summary>
        /// Crear un nuevo Producto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IHttpActionResult Post(Factura ObjFactura)
        {
            if (!ModelState.IsValid)
                return BadRequest("Modelo Invalido");

            Fnegocio = new FachadaNegocio();

            try
            {
                if (Fnegocio.AddFactura(ObjFactura))
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception Ex)
            {
                return InternalServerError(Ex);
            }
        }

        /// <summary>
        /// Editar un Producto.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IHttpActionResult Put(Factura Objfactura, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Modelo Invalido");

            Fnegocio = new FachadaNegocio();

            try
            {
                if (Fnegocio.UpdatedFactura(Objfactura, Id))
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
