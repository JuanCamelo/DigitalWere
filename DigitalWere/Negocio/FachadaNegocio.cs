using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FachadaNegocio
    {
        private ClienteBO ObjClientBO;
        private ProductoBO ObjProductoBO;
        private DetalleBO ObjDetalleBO;
        private FacturaBO ObjFacturaBO;

        #region Cliente
        public bool AddClient(Entidades.Cliente ObjClient)
        {
            ObjClientBO = new ClienteBO();
            return ObjClientBO.AddClient(ObjClient);
        }

        public bool UpdateClient(Entidades.Cliente ObjClient, int Id)
        {
            ObjClientBO = new ClienteBO();
            return ObjClientBO.UpdateCliete(ObjClient, Id);
        }

        public List<Entidades.Cliente> ListaClient()
        {
            ObjClientBO = new ClienteBO();
            return ObjClientBO.ListaClient();
        }

        public bool DeleteClient(int Id)
        {
            ObjClientBO = new ClienteBO();
            return ObjClientBO.DeleteCliente(Id);

        }

        public Entidades.Cliente GetClientById(int Id)
        {
            ObjClientBO = new ClienteBO();
            return ObjClientBO.GetClientById(Id);
        }
        #endregion

        #region Producto
        public bool AddProducto(Entidades.Producto ObjProducto)
        {
            ObjProductoBO = new ProductoBO();
            return ObjProductoBO.AddProducto(ObjProducto);
        }

        public Entidades.Producto GetProductoById(int id)
        {
            ObjProductoBO = new ProductoBO();
            return ObjProductoBO.GetProductoById(id);
        }
        public bool UpdateProducto(Entidades.Producto ObjProducto, int Id)
        {
            ObjProductoBO = new ProductoBO();
            return ObjProductoBO.UpdateProducto(ObjProducto, Id);
        }

        public bool DeleteProducto(int Id)
        {
            ObjProductoBO = new ProductoBO();
            return ObjProductoBO.DeleteProducto(Id);
        }

        public List<Entidades.Producto> ListaProducto()
        {
            ObjProductoBO = new ProductoBO();
            return ObjProductoBO.ListaProducto();
        }
        #endregion

        #region Detalle

        public bool AddDetalle(Entidades.Detalle ObjDetalle)
        {
            ObjDetalleBO = new DetalleBO();
            return ObjDetalleBO.AddDetalle(ObjDetalle);
        }

        public List<Entidades.Detalle> ListDetalle()
        {
            ObjDetalleBO = new DetalleBO();
            return ObjDetalleBO.ListaDetalle();

        }

        #endregion

        #region Factura
        public bool AddFactura(Entidades.Factura ObjFactura)
        {
            ObjFacturaBO = new FacturaBO();
            return ObjFacturaBO.AddFactura(ObjFactura);
        }

        public List<Entidades.Factura> ListaFactura()
        {
            ObjFacturaBO = new FacturaBO();
            return ObjFacturaBO.ListaFactura();
        }

        public Entidades.Factura GetFacturaById(int Id)
        {
            ObjFacturaBO = new FacturaBO();
            return ObjFacturaBO.GetFacturaById(Id);
        }

        public bool UpdatedFactura(Entidades.Factura ObjFac, int id)
        {
            ObjFacturaBO = new FacturaBO();
            return ObjFacturaBO.UpdateFactura(ObjFac, id);
        }
        #endregion
    }
}
