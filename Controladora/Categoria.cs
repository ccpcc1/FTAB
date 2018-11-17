using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN = Entidades;
using BR = Broker;

namespace Controladora
{

    class Categoria
    {
        private BR.BDTiendaDEntities db = new BR.BDTiendaDEntities();

        public List<EN.Categoria> GetCategorias()
        {


            List<BR.Categoria> query = db.Categoria.ToList();
            List<EN.Categoria> listDest = new List<EN.Categoria>();


            //Recorremos la consulta 
            foreach (var item in query)
            {
                EN.Categoria other = new EN.Categoria();
                other.descripcion = item.descripcion;
                other.idCategoria = item.idCategoria;
                other.nombreCat = item.nombreCat;
                //Annadimos a la lista que retornamos
                listDest.Add(other);

            }

            return listDest;

        }

    }
}
