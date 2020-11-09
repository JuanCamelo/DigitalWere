using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Detalle
    {
        public int IdDetalle { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
