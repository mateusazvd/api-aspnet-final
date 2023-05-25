using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend_UniFinal.Models
{
    public class Pesquisa
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<string> Lojas { get; set; } 
        public List<Produto> Produtos { get; set; }
        public string categoria { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public string nome { get; set; }

    }
}
