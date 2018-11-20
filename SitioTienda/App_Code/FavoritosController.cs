using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NQ = noSQL;
using CT = Controladora;

public class FavoritosController : ApiController
{
    CT.Productos ctProdcutos = new CT.Productos();
    // GET api/<controller>/5
    //retorna el producto de la bases de mongo donde nombre es el nombre del usuario
    public List<string> Get()
    {
        NQ.Productos prod = new NQ.Productos();
        NQ.Lista obj = new NQ.Lista();
        prod=obj.Buscar();
        if(prod!=null)
        {
            return prod.producto;
        }
        else
        {
            return new List<string>();
        }
        
    }

    // POST api/<controller>
    public void Post(string product)
    {

        string name = ctProdcutos.getNameProducto(Convert.ToInt32(product));

        NQ.Productos producto = new NQ.Productos();
        producto.id_usuario = 135791;
        
        NQ.Lista obj = new NQ.Lista();
        obj.Modificar(name, producto);
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
