﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;

namespace noSQL
{
    public class Lista
    {
        protected static IMongoClient client = new MongoClient("mongodb://ccpc:123456c@ds139791.mlab.com:39791/tienda");
        protected static IMongoDatabase database = client.GetDatabase("tienda");

        public Productos Buscar()
        {
            Productos product = new Productos();
            var collection = database.GetCollection<BsonDocument>("ListaProductos");
            var filter = Builders<BsonDocument>.Filter.Eq("id_usuario", 135791);
            var result = collection.Find(filter).FirstOrDefault(); ;
            if (result != null)
            {
                product = BsonSerializer.Deserialize<Productos>(result);
                return product;
            }
            else
            {
                return null;
            }

        }

        public void Insertar(Productos producto)
        {
            var collection = database.GetCollection<BsonDocument>("ListaProductos");
            BsonDocument documento = producto.ToBsonDocument();
            collection.InsertOne(documento);
        }

        public void Modificar(string producto, Productos product)
        {
            // var algo = product.id_producto;
            
            var collection = database.GetCollection<BsonDocument>("ListaProductos");
            product = Buscar();
            var filter = Builders<BsonDocument>.Filter.Eq("id_usuario", 135791);
            if (filter != null)
            {
                product.producto.Add(producto);
                collection.ReplaceOne(filter, product.ToBsonDocument());
            }
            else
            {
                Productos nobj = new Productos();
                nobj._id = ObjectId.Parse("" + 135791);
                nobj.producto.Add(producto);
                nobj.nombre = "";
                nobj.id_usuario = 135791;
                Insertar(nobj);

            }

        }

        public Productos Consultar(int id_usuario)
        {
            Productos obj = new Productos();
            var collection = database.GetCollection<BsonDocument>("ListaProductos");
            var filter = Builders<BsonDocument>.Filter.Eq("id_usuario", id_usuario);
            var result = collection.Find(filter).FirstOrDefault();
            if (result == null)
            {

                return null;


            }
            else
            {
                obj = BsonSerializer.Deserialize<Productos>(result);

                return obj;

            }

        }

    }


    public class Productos
    {
        public ObjectId _id { get; set; }
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public List<string> producto { get; set; }



    }
}
