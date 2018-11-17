using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BR = Broker;
using EN = Entidades;
namespace Controladora
{
    public class Productos
    {

        private BR.BDTiendaDEntities db = new BR.BDTiendaDEntities();

        public List<EN.Producto> GetProductos()
        {

            List<EN.Producto> productos = new List<EN.Producto>();

            var query = db.Productos.ToList();

            foreach (var item in query)
            {
                EN.Producto p = new EN.Producto();
                p.Categoria = item.Categoria.nombreCat;
                p.idCategoria = item.idCategoria;
                p.idProducto = item.idProducto;
                p.idProvedor = item.Provedores.nombreProv;
                p.nombreProducto = item.nombreProducto;
                p.img = item.img;
                p.Precio = item.Precio;
                p.stock = item.stock;

                productos.Add(p);
            }

            return productos;
        }

        public List<EN.Producto> GetProductos(int id)
        {

            List<EN.Producto> productos = new List<EN.Producto>();

            var query = db.Productos.Where(x => x.idCategoria == id);

            foreach (var item in query)
            {
                EN.Producto p = new EN.Producto();
                p.Categoria = item.Categoria.nombreCat;
                p.idCategoria = item.idCategoria;
                p.idProducto = item.idProducto;
                p.idProvedor = item.Provedores.nombreProv;
                p.nombreProducto = item.nombreProducto;
                p.img = item.img;
                p.Precio = item.Precio;
                p.stock = item.stock;

                productos.Add(p);
            }

            return productos;
        }

        public EN.Producto GetProducto(int id,bool value)
        {
            EN.Producto p = new EN.Producto();
            BR.Productos other = db.Productos.Where(x => x.idProducto == id).FirstOrDefault();

            p.Categoria = other.Categoria.nombreCat;
            p.idCategoria = other.idCategoria;
            p.idProducto = other.idProducto;
            p.idProvedor = other.Provedores.nombreProv;
            p.nombreProducto = other.nombreProducto;
            p.img = other.img;
            p.Precio = other.Precio;
            p.stock = other.stock;
            
            return p;
        }
    }
}
