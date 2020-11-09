using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class FachadaPersistencia
    {
        private static FachadaPersistencia instancia;
        public static FachadaPersistencia Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new FachadaPersistencia();
                return instancia;

            }
        }

        #region Cliente
        /// <summary>
        /// Metodo que me permite registrar un nuevo cliente
        /// </summary>
        /// <param name="ObjClient"></param>
        /// <returns></returns>
        public bool AddClient(Entidades.Cliente ObjClient)
        {
            bool valid = false;
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Cliente Obj = new Cliente();
                    Obj.Identificacion = ObjClient.Identificacion;
                    Obj.Nombre = ObjClient.Nombre;
                    Obj.Apellido = ObjClient.Apellido;
                    Obj.FechaNacimiento = ObjClient.FechaNacimiento;
                    Obj.Telefono = ObjClient.Telefono;
                    Obj.Email = ObjClient.Email;

                    Cone.Cliente.Add(Obj);
                    Cone.SaveChanges();
                    valid = true;
                }

            }
            catch (Exception ex)
            {
                valid = false;
            }
            return valid;
        }


        /// <summary>
        /// Metodo que consulta y recupera un cliente por ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Entidades.Cliente GetClietById(int Id)
        {
            Entidades.Cliente ObjCliet = new Entidades.Cliente();
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Cliente Obj = Cone.Cliente.Where(x => x.IdCliente == Id).FirstOrDefault();
                    if (Obj != null)
                    {
                        ObjCliet.IdCliente = Obj.IdCliente;
                        ObjCliet.Identificacion = Obj.Identificacion;
                        ObjCliet.Nombre = Obj.Nombre;
                        ObjCliet.Apellido = Obj.Apellido;
                        ObjCliet.FechaNacimiento = Obj.FechaNacimiento;
                        ObjCliet.Telefono = Obj.Telefono;
                        ObjCliet.Email = Obj.Email;

                    }
                }

            }
            catch (Exception ex)
            {

                ObjCliet = new Entidades.Cliente();
            }
            return ObjCliet;
        }

        /// <summary>
        /// Metodo que permite actializar un cliente
        /// </summary>
        /// <param name="ObjClient"></param>
        /// <returns></returns>
        public bool UpdateClient(Entidades.Cliente ObjClient, int Id)
        {
            bool Valid = false;
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Cliente Obj = Cone.Cliente.Where(x => x.IdCliente == Id).FirstOrDefault();
                    if (Obj != null)
                    {
                        Obj.Identificacion = ObjClient.Identificacion;
                        Obj.Nombre = ObjClient.Nombre;
                        Obj.Apellido = ObjClient.Apellido;
                        Obj.FechaNacimiento = ObjClient.FechaNacimiento;
                        Obj.Telefono = ObjClient.Telefono;
                        Obj.Email = ObjClient.Email;

                        Cone.Entry(Obj).State = System.Data.Entity.EntityState.Modified;
                        Cone.SaveChanges();
                        Valid = true;
                    }

                }

            }
            catch (Exception ex)
            {

                Valid = false;
            }
            return Valid;
        }


        /// <summary>
        /// Metodo que recupera la lista de los clietes
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Cliente> ListClient()
        {
            List<Entidades.Cliente> ListClien = new List<Entidades.Cliente>();
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    ListClien = (from Obj in Cone.Cliente
                                 select new Entidades.Cliente
                                 {
                                     IdCliente = Obj.IdCliente,
                                     Identificacion = Obj.Identificacion,
                                     Nombre = Obj.Nombre,
                                     Apellido = Obj.Apellido,
                                     FechaNacimiento = Obj.FechaNacimiento,
                                     Telefono = Obj.Telefono,
                                     Email = Obj.Email
                                 }).ToList();
                }

            }
            catch (Exception ex)
            {

                ListClien = new List<Entidades.Cliente>();
            }
            return ListClien;
        }

        /// <summary>
        /// Metodo que permite consultar y eliminar un cliente por el Id 
        /// </summary>
        /// <param name="IdClient"></param>
        /// <returns></returns>
        public bool DeleteClient(int IdClient)
        {
            bool Valid = false;
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Cliente Obj = Cone.Cliente.Where(x => x.IdCliente == IdClient).First();
                    if (Obj != null)
                    {
                        Factura ObjFac = Cone.Factura.Where(x => x.IdCliente == Obj.IdCliente).First();

                        if (ObjFac != null)
                        {
                            Detalle ObjDetalle = Cone.Detalle.Where(x => x.IdFactura == ObjFac.IdFactura).FirstOrDefault();
                            if (ObjDetalle != null)
                            {
                                Cone.Detalle.Remove(ObjDetalle);                            
                                                            
                            }
                            Cone.Factura.Remove(ObjFac);
                           
                        }

                        Cone.Cliente.Remove(Obj);
                        Cone.SaveChanges();
                        Valid = true;
                    }

                }
            }
            catch (Exception ex)
            {

                Valid = false;
            }
            return Valid;
        }



        #endregion

        #region Facturacion

        /// <summary>
        /// Metodo que permite agregar nuevas facturas
        /// </summary>
        /// <param name="ObjFactura"></param>
        /// <returns></returns>
        public bool AddFactura(Entidades.Factura ObjFactura)
        {
            bool Valid = false;
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Factura Obj = new Factura();
                    Obj.IdCliente = ObjFactura.IdCliente;
                    Obj.FechaFactura = ObjFactura.FechaFactura;
                    Obj.FechaUltimaCompra = ObjFactura.FechaUltimaCompra;

                    Cone.Factura.Add(Obj);
                    Cone.SaveChanges();
                    Valid = true;

                }

            }
            catch (Exception ex)
            {
                Valid = false;
            }
            return Valid;
        }

        /// <summary>
        /// Medoto que consulta y recupera una factura por el id 
        /// </summary>
        /// <param name="IdFactura"></param>
        /// <returns></returns>
        public Entidades.Factura GetFacturaById(int IdFactura)
        {
            Entidades.Factura ObjFactura = new Entidades.Factura();
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Factura Obj = Cone.Factura.Where(x => x.IdFactura == IdFactura).FirstOrDefault();
                    if (Obj != null)
                    {
                        ObjFactura.IdFactura = Obj.IdFactura;
                        ObjFactura.IdCliente = Obj.IdCliente;
                        ObjFactura.FechaFactura = Obj.FechaFactura;
                        ObjFactura.FechaUltimaCompra = Obj.FechaUltimaCompra;
                    }
                }
            }
            catch (Exception ex)
            {

                ObjFactura = new Entidades.Factura();
            }
            return ObjFactura;
        }


        /// <summary>
        /// Metodo que permite actualizar un registr de factura 
        /// </summary>
        /// <param name="ObjFactura"></param>
        /// <returns></returns>
        public bool UpdateFactura(Entidades.Factura ObjFactura, int Id)
        {
            bool Valid = false;
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Factura Obj = Cone.Factura.Where(x => x.IdCliente == Id).FirstOrDefault();
                    if (Obj != null)
                    {
                        Obj.IdCliente = ObjFactura.IdCliente;

                        Cone.Entry(Obj).State = System.Data.Entity.EntityState.Modified;
                        Cone.SaveChanges();
                        Valid = true;
                    }

                }
            }
            catch (Exception ex)
            {

                Valid = false;
            }
            return Valid;
        }

        /// <summary>
        /// Metodo para generar una lista de facturas
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Factura> ListaFactura()
        {
            List<Entidades.Factura> ListFactur = new List<Entidades.Factura>();
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    ListFactur = (from Obj in Cone.Factura
                                  select new Entidades.Factura
                                  {
                                      IdCliente = Obj.IdCliente,
                                      IdFactura = Obj.IdFactura,
                                      FechaFactura = Obj.FechaFactura,
                                      FechaUltimaCompra = Obj.FechaUltimaCompra
                                  }).ToList();

                }
            }
            catch (Exception ex)
            {

                ListFactur = new List<Entidades.Factura>();
            }
            return ListFactur;
        }

        #endregion

        #region Producto
        /// <summary>
        /// Metodo que permite Agregar nuevos Productos 
        /// </summary>
        /// <param name="ObjProduc"></param>
        /// <returns></returns>
        public bool AddProducto(Entidades.Producto ObjProduc)
        {
            bool valid = true;
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Producto Obj = new Producto();
                    Obj.NombreProducto = ObjProduc.NombreProducto;
                    Obj.Precio = ObjProduc.Precio;
                    Obj.Stock = ObjProduc.Stock;

                    Cone.Producto.Add(Obj);
                    Cone.SaveChanges();
                    valid = true;

                }
            }
            catch (Exception ex)
            {

                valid = false;
            }
            return valid;
        }

        /// <summary>
        /// Metodo que consulta y recupera un producto por el Id
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <returns></returns>
        public Entidades.Producto GetProductoById(int IdProducto)
        {
            Entidades.Producto ObjProducto = new Entidades.Producto();
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Producto Obj = Cone.Producto.Where(X => X.IdProducto == IdProducto).FirstOrDefault();
                    if (Obj != null)
                    {
                        ObjProducto.IdProducto = Obj.IdProducto;
                        ObjProducto.NombreProducto = Obj.NombreProducto;
                        ObjProducto.Precio = Obj.Precio;
                        ObjProducto.Stock = Obj.Stock;

                    }
                }

            }
            catch (Exception ex)
            {

                ObjProducto = new Entidades.Producto();
            }
            return ObjProducto;
        }

        /// <summary>
        /// Metodo que permite actualizar un Producto
        /// </summary>
        /// <param name="ObjProducto"></param>
        /// <returns></returns>        
        public bool UpdateProducto(Entidades.Producto ObjProducto, int Id)
        {
            bool Valid = false;
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Producto Obj = Cone.Producto.Where(X => X.IdProducto == Id).FirstOrDefault();
                    if (Obj != null)
                    {
                        Obj.NombreProducto = ObjProducto.NombreProducto;
                        Obj.Precio = ObjProducto.Precio;
                        Obj.Stock = ObjProducto.Stock;

                        Cone.Entry(Obj).State = System.Data.Entity.EntityState.Modified;
                        Cone.SaveChanges();
                        Valid = true;
                    }

                }
            }
            catch (Exception ex)
            {

                Valid = false;
            }
            return Valid;
        }

        /// <summary>
        /// Metodo que permiteobtener una lista de Productos 
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Producto> ListaProducto()
        {
            List<Entidades.Producto> ListaProduc = new List<Entidades.Producto>();
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    ListaProduc = (from Obj in Cone.Producto
                                   select new Entidades.Producto
                                   {
                                       IdProducto = Obj.IdProducto,
                                       NombreProducto = Obj.NombreProducto,
                                       Precio = Obj.Precio,
                                       Stock = Obj.Stock
                                   }).ToList();

                }

            }
            catch (Exception ex)
            {

                ListaProduc = new List<Entidades.Producto>();
            }
            return ListaProduc;
        }


        public bool delteProducto(int Id)
        {
            bool Valid = false;
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Producto Obj = Cone.Producto.Where(X => X.IdProducto == Id).FirstOrDefault();
                    if (Obj != null)
                    {
                        Cone.Producto.Remove(Obj);
                        Cone.SaveChanges();
                        Valid = true;
                    }

                }
            }
            catch (Exception ex)
            {

                Valid = false;
            }
            return Valid;
        }

        #endregion

        #region Detalle
        /// <summary>
        /// Metodo para agregar nuevos detalles 
        /// </summary>
        /// <param name="ObjDetalle"></param>
        /// <returns></returns>
        public bool AddDetalle(Entidades.Detalle ObjDetalle)
        {
            bool Valid = false;
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    Detalle Obj = new Detalle();
                    Obj.IdDetalle = ObjDetalle.IdDetalle;
                    Obj.IdFactura = ObjDetalle.Factura.IdFactura;
                    Obj.IdProducto = ObjDetalle.Producto.IdProducto;
                    Obj.Cantidad = ObjDetalle.Cantidad;
                    Obj.PrecioVenta = ObjDetalle.PrecioVenta;

                    Cone.Detalle.Add(Obj);
                    Cone.SaveChanges();
                    Valid = true;
                }
            }
            catch (Exception ex)
            {

                Valid = false;
            }
            return Valid;
        }

        /// <summary>
        /// Metodo que consulta la lista de los detalles 
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Detalle> ListaDetalle()
        {
            List<Entidades.Detalle> ListaDe = new List<Entidades.Detalle>();
            try
            {
                using (FacturacionEntities Cone = new FacturacionEntities())
                {
                    ListaDe = (from Obj in Cone.Detalle
                               select new Entidades.Detalle
                               {
                                   IdDetalle = Obj.IdDetalle,
                                   Factura = new Entidades.Factura { IdFactura = Obj.IdFactura },
                                   Producto = new Entidades.Producto { IdProducto = Obj.IdProducto },
                                   Cantidad = Obj.Cantidad,
                                   PrecioVenta = Obj.PrecioVenta
                               }).ToList();

                }
            }
            catch (Exception ex)
            {

                ListaDe = new List<Entidades.Detalle>();
            }
            return ListaDe;
        }

        #endregion
    }
}
