using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using En = Entidades;
using CT = Controladora;

public class DetalleFacturaController : ApiController
{

    CT.DetalleFactura ctDetalleFactura = new CT.DetalleFactura();
    CT.Factura ctFactura = new CT.Factura();
    CT.Productos ctProductos = new CT.Productos();

    // GET api/<controller>
    public List<En.DetalleFactura> Get()
    {
        return ctDetalleFactura.GetDetalleFacturas();
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<controller>
    public void Post(int[]idProductos, int[]cantidades)
    {
        En.Factura fact= new En.Factura();
        fact.FechaFactura = System.DateTime.Today;
        fact.descuento = 5; //descuento porque estamos en prueba
        
        int j = idProductos.Length;
        int monto = 0;

        for (int i = 0; i < j; i++)
        {
            //Monto total
            monto += ctProductos.GetProducto(idProductos[i], true).Precio * cantidades[i];
            //Disminuir el stock
            ctProductos.changeStock(idProductos[i], ctProductos.GetProducto(idProductos[i], true).stock - cantidades[i]);

        }

        fact.montoFinal = monto;
        ctFactura.Crear(fact);
        //Obtener el id de la facura

        int idFactura = ctFactura.getIdFactura(fact.FechaFactura);

        //ingresamos los productos uno por uno a detalle factura
        for (int i = 0; i < j; i++)
        {
            En.DetalleFactura dfact = new En.DetalleFactura();
            dfact.idFactura = idFactura;
            dfact.precioUnitario = ctProductos.GetProducto(idProductos[i], true).Precio;
            dfact.nombres = ctProductos.getNameProducto(idProductos[i]);
            dfact.cantidad = cantidades[i];
            ctDetalleFactura.Crear(dfact);

        }

    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
    }
}
