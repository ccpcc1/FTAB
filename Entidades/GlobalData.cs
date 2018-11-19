using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GlobalData
    {
        public static List<int> car = new List<int>();
        public static List<int> cantidad = new List<int>();

        public static void annadirCarrito(int id)
        {

            int posProducto = 0;
            int cantidadProdcuto = 0;

            if (car.Contains(id))
            {
                posProducto = car.IndexOf(id);
                cantidadProdcuto = cantidad[posProducto]; 
                cantidadProdcuto++;
                cantidad.Insert(posProducto, cantidadProdcuto);
            }
            else {

                car.Add(id);

                cantidad.Add(1);

            }
            

        }

        public static List<int> getCar()
        {

            return car;

        }
        public static List<int> getCantidad()
        {

            return cantidad;

        }


    };
}
