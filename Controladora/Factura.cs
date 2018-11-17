using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BR = Broker;
using EN = Entidades;

namespace Controladora
{
    public class Factura
    {

        private BR.BDTiendaDEntities db = new BR.BDTiendaDEntities();

        public bool Crear(EN.Factura factura)
        {
            bool resultado = false;

            try
            {
                AutoMapper.Mapper.CreateMap<EN.Factura, BR.Factura>();
                BR.Factura fact = AutoMapper.Mapper.Map<BR.Factura>(factura);
                db.Factura.Add(fact);
                db.SaveChanges();

                //Al annaidr una factura debemos annadir un detalleFactura y disminuir el Stock
                //Consulta del id de la factura asociada al cliente
                var consulta = from fac in db.Factura
                               where (fac.Cliente == fact.Cliente && fac.FechaFactura == fact.FechaFactura)
                               select new { fac.idFactura };

                foreach (var item in consulta)
                {
                    factura.idFactura = item.idFactura;
                }

                for (int i = 0; i < factura.DetallesFactura.Count; i++)
                {
                    BR.DetalleFactura detalleFactura = new BR.DetalleFactura();
                    detalleFactura.idFactura = factura.idFactura;
                    detalleFactura.idProducto = factura.DetallesFactura[i].idProducto;
                    detalleFactura.cantidad = factura.DetallesFactura[i].cantidad;

                    BR.Productos producto = db.Productos.Find(factura.DetallesFactura[i].idProducto);
                    producto.stock = producto.stock - factura.DetallesFactura[i].cantidad;

                    db.DetalleFactura.Add(detalleFactura);
                    db.SaveChanges();
                }


                resultado = true;

            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }

        public List<EN.Factura> GetFacturas()
        {


            List<BR.Factura> query = db.Factura.ToList();
            List<EN.Factura> listDest = new List<EN.Factura>();
           

            //Recorremos la consulta 
            foreach (var item in query)
            {
                EN.Factura other = new EN.Factura();
                other.descuento = item.descuento;
                other.FechaFactura = item.FechaFactura;
                other.idCliente = item.Cliente.nombre;
                other.idFactura = item.idFactura;
                other.montoFinal = item.montoFinal;

                //Annadimos a la lista que retornamos
                listDest.Add(other);

            }


            return listDest;

        }
        public EN.Factura GetFactura(int id)
        {

            try
            {
                BR.Factura fac = db.Factura.Where(x => x.idFactura == id).FirstOrDefault();
                AutoMapper.Mapper.CreateMap<BR.Factura, EN.Factura>();
                EN.Factura fact = AutoMapper.Mapper.Map<EN.Factura>(fac);
                return fact;

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
