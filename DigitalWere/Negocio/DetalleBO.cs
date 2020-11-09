using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DetalleBO
    {
        internal bool AddDetalle(Entidades.Detalle ObjDetalle)
        {
            return FachadaPersistencia.Instancia.AddDetalle(ObjDetalle);
        }

        internal List<Entidades.Detalle> ListaDetalle()
        {
            return FachadaPersistencia.Instancia.ListaDetalle();
        }
    }
}
