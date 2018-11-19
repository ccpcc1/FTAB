using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
    public void Post(NQ.Objeto objec)
    {
        NQ.ObjetoMg obj = new NQ.ObjetoMg();
        obj.Modificar(objec.comentarios[0], obj.Buscar(objec.id_producto));
        
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
