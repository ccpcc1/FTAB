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

        public static void annadirCarrito(int id) {

            car.Add(id);
           
        }
        
        public static List<int> getCar()
        {

            return car;

        }


    };
}
