using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleFactura
    {

        public int idFactura { get; set; }
        public string nombres { get; set; }
        public int precioUnitario { get; set; }
        public int cantidad { get; set; }

    }
}
