using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoBO
    {

        /// <summary>
        /// Metodo que perimite validar la logica del negocio
        /// </summary>
        /// <param name="ObjProducto"></param>
        /// <returns></returns>
        internal bool AddProducto(Entidades.Producto ObjProducto)
        {
            return FachadaPersistencia.Instancia.AddProducto(ObjProducto);
        }

        /// <summary>
        /// metodo que Permite Actualizar un producto
        /// </summary>
        /// <param name="ObjProducto"></param>
        /// <returns></returns>
        internal bool UpdateProducto(Entidades.Producto ObjProducto, int Id)
        {
            return FachadaPersistencia.Instancia.UpdateProducto(ObjProducto, Id);
        }

        /// <summary>
        /// metodo que permite Consultar un producto por el Id  
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <returns></returns>
        internal Entidades.Producto GetProductoById(int IdProducto)
        {
            return FachadaPersistencia.Instancia.GetProductoById(IdProducto);
        }

        /// <summary>
        /// Metodo que sierve para consultar una lista de productos 
        /// </summary>
        /// <returns></returns>
        internal List<Entidades.Producto> ListaProducto()
        {
            return FachadaPersistencia.Instancia.ListaProducto();
        }

        /// <summary>
        /// metodo que sirve para eliminar productos
        /// </summary>
        /// <param name="ObjProducto"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        internal bool DeleteProducto(int Id)
        {
            return FachadaPersistencia.Instancia.delteProducto(Id);
        }

    }
}
