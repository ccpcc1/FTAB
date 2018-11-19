using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NQ = noSQL;

public class FavoritosController : ApiController
{
    // GET api/<controller>
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<controller>/5
    //retorna el producto de la bases de mongo donde nombre es el nombre del usuario
    public NQ.Productos Get(string nombre)
    {
        NQ.Lista obj = new NQ.Lista();
        return obj.Buscar(nombre);
    }

    // POST api/<controller>
    public void Post(string nombre)
    {
        NQ.Lista obj = new NQ.Lista();
        obj.Insertar(obj.Buscar(nombre));
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
