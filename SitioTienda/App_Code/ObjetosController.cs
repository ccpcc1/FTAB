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
    // GET api/<controller>
    public IEnumerable<string> Get()
    {
        return new string[] { "value154", "value2" };
    }

    // GET api/<controller>/5
    public NQ.Objeto Get(int id)
    {
        NQ.ObjetoMg obj = new NQ.ObjetoMg();
        return obj.Buscar(id);
    }

    // POST api/<controller>
    //agregar comentario
    [ResponseType(typeof(NQ.Comentar))]
    public void Post(NQ.Comentar com)
    {
        NQ.Comentar c = new NQ.Comentar();
        c.idProducto = com.idProducto;
        c.comentario = com.comentario;

        NQ.ObjetoMg obj = new NQ.ObjetoMg();
        obj.Modificar(c.comentario, obj.Buscar(c.idProducto));
        
    }

    //añadir calificacion
    public void Post(int calificacion, int id)
    {
        NQ.ObjetoMg obj = new NQ.ObjetoMg();
        obj.Modificar(calificacion, obj.Buscar(id));


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
