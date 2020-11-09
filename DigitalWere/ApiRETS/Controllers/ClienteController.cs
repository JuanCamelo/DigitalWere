using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiRETS.App_Start;
using Entidades;
using Negocio;

namespace ApiRETS.Models
{
    public class ClienteController : ApiController
    {
        FachadaNegocio Fnegocio = new FachadaNegocio();
        public IHttpActionResult Get()
        {
            

            List<Cliente> LstCliete = null;
            Fnegocio = new FachadaNegocio();
            try
            {
                LstCliete = Fnegocio.ListaClient();

                if (LstCliete == null)
                {
                    return NotFound();
                }

                return Json(LstCliete);
            }
            catch (Exception Ex)
            {
                return InternalServerError(Ex);
            }
        }

        /// <summary>
        /// Obtener un producot por el id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int Id)
        {
            Cliente ObjCliente = null;
            Fnegocio = new FachadaNegocio();
            try
            {
                ObjCliente = Fnegocio.GetClientById(Id);

                if (ObjCliente.IdCliente == 0)
                {
                    return NotFound();
                }

                return Ok(ObjCliente);
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
        public IHttpActionResult Post(Cliente ObjCliente)
        {
            if (!ModelState.IsValid)
                return BadRequest("Modelo Invalido");

            Fnegocio = new FachadaNegocio();

            try
            {
                if (Fnegocio.AddClient(ObjCliente))
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
        public IHttpActionResult Put(Cliente ObjCliet, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Modelo Invalido");

            Fnegocio = new FachadaNegocio();

            try
            {
                if (Fnegocio.UpdateClient(ObjCliet, Id))
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
        public IHttpActionResult Delete(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Modelo Invalido");

            Fnegocio = new FachadaNegocio();

            try
            {
                if (Fnegocio.DeleteClient(Id))
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
