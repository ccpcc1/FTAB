using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EN = Entidades;
using CT = Controladora;

public class ProductosController : ApiController
{
    CT.Productos c = new CT.Productos();
    // GET api/<controller>
    public List<EN.Producto> Get()
    {
        return c.GetProductos();
    }

    //GET api/<controller>/5
    public List<EN.Producto> Get(int id)
    {
        return c.GetProductos(id);
    }

    //GET api/<controller>/5
    public EN.Producto Get(int id, bool value)
    {
        return c.GetProducto(id);
    }

    // POST api/<controller>
    public void Post([FromBody]string value)
    {
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
