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
    public class ProductoController : ApiController
    {
        FachadaNegocio Fnegocio = new FachadaNegocio();
        public IHttpActionResult Get()
        {
            List<Producto> LstProducto = null;
            Fnegocio = new FachadaNegocio();
            try
            {
                LstProducto = Fnegocio.ListaProducto();

                if (LstProducto == null)
                {
                    return NotFound();
                }

                return Ok(LstProducto);
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
            Producto ObjProducto = null;
            Fnegocio = new FachadaNegocio();
            try
            {
                ObjProducto = Fnegocio.GetProductoById(Id);

                if (ObjProducto.IdProducto == 0)
                {
                    return NotFound();
                }

                return Ok(ObjProducto);
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
        public IHttpActionResult Post(Producto ObjProducto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Modelo Invalido");

            Fnegocio = new FachadaNegocio();

            try
            {
                if (Fnegocio.AddProducto(ObjProducto))
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
        public IHttpActionResult Put(Producto ObjProducto, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Modelo Invalido");

            Fnegocio = new FachadaNegocio();

            try
            {
                if (Fnegocio.UpdateProducto(ObjProducto, Id))
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
                if (Fnegocio.DeleteProducto(Id))
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
