using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {

        public int idFactura { get; set; }
        public System.DateTime FechaFactura { get; set; }
        public String idCliente { get; set; }
        public int descuento { get; set; }
        public int montoFinal { get; set; }
        public List<DetalleFactura> DetallesFactura { get; set; }
    }
}
