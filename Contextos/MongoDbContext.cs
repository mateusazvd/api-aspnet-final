using Backend_UniFinal.Models;
using MongoDB.Driver;

namespace Backend_UniFinal.Contextos
{
    public class MongoDbContext
    {
        public string ConnectionString { get; set; }

        public string Database { get; set; }

        public string PesquisaCollection { get; set; }
        public string RespostaCollection { get; set; }


    }
}
