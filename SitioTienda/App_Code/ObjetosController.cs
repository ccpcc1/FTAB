using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NQ = noSQL;

public class ObjetosController : ApiController
{

    NQ.Comentar c = new NQ.Comentar();
    // GET api/<controller>
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<controller>/5
    public NQ.Objeto Get(int id)
    {
        NQ.ObjetoMg obj = new NQ.ObjetoMg();
        return obj.Buscar(id);
    }

    // POST api/<controller>
    //agregar comentario
    public void Post(int id, string comentario)
    {
        
        NQ.ObjetoMg obj = new NQ.ObjetoMg();
        obj.Modificar(comentario, obj.Buscar(id));

    }

    //añadir calificacion
    public void Post(int id, int cal)
    {
        NQ.ObjetoMg obj = new NQ.ObjetoMg();
        obj.Modificar(cal, obj.Buscar(id));


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
