using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.IO;

namespace noSQL
{
    public class ObjetoMg
    {

        public static IMongoClient client = new MongoClient("mongodb://ccpc:123456c@ds139791.mlab.com:39791/tienda");
        public static IMongoDatabase database = client.GetDatabase("tienda");

        

        public Objeto Buscar(int producto)
        {
            Objeto obj = new Objeto();
            var collection = database.GetCollection<BsonDocument>("Producto");
            var filter = Builders<BsonDocument>.Filter.Eq("id_producto", producto);
            var result = collection.Find(filter).FirstOrDefault();
            
            if (result==null)
            {

                return null;


            }
            else
            {
                obj = BsonSerializer.Deserialize<Objeto>(result);

                return obj;
                
            }

        }

        public void Insertar(Objeto producto)
        {
            var collection = database.GetCollection<BsonDocument>("Producto");
            BsonDocument documento = producto.ToBsonDocument();
            collection.InsertOne(documento);
        }

        public void Modificar(string comentario, Objeto product)
        {
           // var algo = product.id_producto;
            var collection = database.GetCollection<BsonDocument>("Producto");
            var filter = Builders<BsonDocument>.Filter.Eq("id_producto", product.id_producto);
            if(filter!=null)
            {
                product.comentarios.Add(comentario);
                collection.ReplaceOne(filter, product.ToBsonDocument());
            }
            else
            {
                Objeto nobj = new Objeto();
                nobj._id = ObjectId.Parse(""+product.id_producto);
                nobj.comentarios.Add(comentario);
                Insertar(nobj);

            }
            
        }

        public void Modificar(int puntuacion, Objeto product)
        {
            var collection = database.GetCollection<BsonDocument>("Producto");
            var filter = Builders<BsonDocument>.Filter.Eq("id_producto", product.id_producto);

            if(filter!=null)
            {
                product.puntuacion = product.puntuacion + puntuacion;
                product.cantper += 1;
                collection.ReplaceOne(filter, product.ToBsonDocument());

            }
            else
            {
                Objeto nobj = new Objeto();
                nobj._id = ObjectId.Parse("" + product.id_producto);
                nobj.puntuacion = product.puntuacion;
                nobj.cantper = 1;
                Insertar(nobj);
            }

        }



    }
    public class Objeto
    {
        public ObjectId _id { get; set; }
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public List<string> comentarios { get; set; }

        public int puntuacion { get; set; }

        public int cantper { get; set; }

        public Objeto()
        {

        }

        public static explicit operator Objeto(BsonValue v)
        {
            throw new NotImplementedException();
        }
    }

}

