using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend_UniFinal.Models
{
    public class Resposta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PesquisaId { get; set; }
        public string ProdutoId { get;set; }
        public string LojaId { get; set; }

        public double Preco_Regular { get; set; }

        public double Pague_leve{ get; set; }

        public double Preco_promo { get; set; }

        public string Url_Imagem { get; set; }
        public string Loja_concorrente { get;set; }

    }
}
