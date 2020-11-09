using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FacturaBO
    {
        internal bool AddFactura(Entidades.Factura ObjFactura)
        {
            return FachadaPersistencia.Instancia.AddFactura(ObjFactura);
        }

        internal List<Entidades.Factura> ListaFactura()
        {
            return FachadaPersistencia.Instancia.ListaFactura();
        }


        internal Entidades.Factura GetFacturaById(int Id)
        {
            return FachadaPersistencia.Instancia.GetFacturaById(Id);
        }

        internal bool UpdateFactura(Entidades.Factura ObjFactura, int id)
        {
            return FachadaPersistencia.Instancia.UpdateFactura(ObjFactura, id);
        }

    }
}
