using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Producto
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string img { get; set; }
        public int stock { get; set; }
        public string Categoria { get; set; }
        public int idCategoria { get; set; }
        public string idProvedor { get; set; }
        public int Precio { get; set; }
    }
}
