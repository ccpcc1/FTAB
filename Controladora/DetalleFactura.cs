using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BR = Broker;
using EN = Entidades;
using CT = Controladora;
namespace Controladora
{
    public class DetalleFactura
    {
        private BR.BDTiendaDEntities db = new BR.BDTiendaDEntities();
        private CT.Productos ctProducto = new CT.Productos();

        public bool Crear(EN.DetalleFactura other) {

            bool resultado = false;
            BR.DetalleFactura df = new BR.DetalleFactura();

            try
            {
                //se crea el detalle factura en la base de datos

                df.cantidad = other.cantidad;
                df.idFactura = other.idFactura;
                df.idProducto = ctProducto.getIdProducto(other.nombres);
                df.precioUnitario = other.precioUnitario;
                db.DetalleFactura.Add(df);
                db.SaveChanges();
               
                //var consulta = from Productos in db.Productos
                //               where (Productos.idProducto == detfac.idProducto)
                //               select Productos;
                

                resultado = true;
                //disminuir el stock

                //Al annaidr una factura debemos annadir un detalleFactura y disminuir el Stock
                //Consulta del id de la factura asociada al cliente



                //foreach (var item in consulta)
                //{
                //    factura.idFactura = item.idFactura;
                //}

                //for (int i = 0; i < factura.DetallesFactura.Count; i++)
                //{
                //    BR.DetalleFactura detalleFactura = new BR.DetalleFactura();
                //    detalleFactura.idFactura = factura.idFactura;
                //    detalleFactura.idProducto = factura.DetallesFactura[i].idProducto;
                //    detalleFactura.cantidad = factura.DetallesFactura[i].cantidad;

                //    BR.Productos producto = db.Productos.Find(factura.DetallesFactura[i].idProducto);
                //    producto.stock = producto.stock - factura.DetallesFactura[i].cantidad;

                //    db.DetalleFactura.Add(detalleFactura);
                //    db.SaveChanges();
                //}

                
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;

        }

        public List<EN.DetalleFactura> GetDetalleFacturas() {


            List<BR.DetalleFactura> query = db.DetalleFactura.ToList();
            List<EN.DetalleFactura> listDest = new List<EN.DetalleFactura>();


            //Recorremos la consulta 
            foreach (var item in query)
            {
                EN.DetalleFactura other = new EN.DetalleFactura();

                other.cantidad = item.cantidad;
                other.idFactura = item.idFactura;
                other.nombres = item.Productos.nombreProducto;
                other.precioUnitario = item.precioUnitario;

                //Annadimos a la lista que retornamos
                listDest.Add(other);

            }


            return listDest;
        }


    }



   
}
