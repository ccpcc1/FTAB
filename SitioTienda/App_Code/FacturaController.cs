using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EN = Entidades;
using CT = Controladora;

public class FacturaController : ApiController
{
    CT.Factura factura = new CT.Factura();

    // GET api/<controller>
    public List<EN.Factura> Get()
    {
      
        return factura.GetFacturas();
        
    }

    // GET api/<controller>/5
    public EN.Factura Get(int id)
    {
        return factura.GetFactura(id);
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
