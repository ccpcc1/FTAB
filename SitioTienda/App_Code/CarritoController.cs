using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EN = Entidades;
using CT = Controladora;

public class CarritoController : ApiController
{
    CT.Productos ct = new CT.Productos();

    // GET api/<controller>
    public List<EN.Producto> Get()
    {
        List<int> productos = EN.GlobalData.getCar();
    
        List<EN.Producto> producto = new List<EN.Producto>();

        foreach (int item in productos)
        {

            producto.Add(ct.GetProducto(item,true));

        }
        return producto;
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<controller>
    public void Post(int id)
    {
        EN.GlobalData.annadirCarrito(id);
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
