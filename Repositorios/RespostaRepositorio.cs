using Backend_UniFinal.Contextos;
using Backend_UniFinal.Dto;
using Backend_UniFinal.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Backend_UniFinal.Repositorios
{
    public class RespostaRepositorio
    {

        private readonly IMongoCollection<Resposta> _resposta;
        private readonly IMongoCollection<Pesquisa> _pesquisas;
        public RespostaRepositorio(IOptions<MongoDbContext> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var db = mongoClient.GetDatabase(options.Value.Database);

            _resposta = db.GetCollection<Resposta>
                (options.Value.RespostaCollection);

            _pesquisas = db.GetCollection<Pesquisa>
                (options.Value.PesquisaCollection);
        }

        //Cadastrar nova resposta
        public  Resposta  CadastroResposta(Resposta resposta)
        {
            _resposta.InsertOne(resposta);
            return resposta;
        }
        //Pegar todas as respostas
        public List<Resposta> Respostas_get_todas()
        {
            var result = _resposta.Find(_=>true).ToList();
            return result;
        }
        //Pegar resposta Por Id
        public Resposta Respostas_get_id(string id)
        {
            var result = _resposta.Find(e => e.Id == id).FirstOrDefault();
            return result;
        }

        //Pegar resposta por pesquisa
        public List<Resposta> Respostas_por_pesquisa(string idPesquisa)
        {
            var result = _resposta.Find(e => e.PesquisaId == idPesquisa).ToList();
            return result;
        }

        //Pegar Resposta por pesquisa e por loja
        public List<Resposta> Resposta_por_loja(string pesquisaId, string lojaId)
        {
            var result = _resposta.Find(e => e.PesquisaId == pesquisaId && e.LojaId == lojaId).ToList();
            return result;
        }

        //Apagar resposta por Id
        public List<Resposta> ApagarResposta(string id)
        {
            var resposta = _resposta.Find(e => e.Id == id).FirstOrDefault();
            _resposta.DeleteOne(e => e.Id == id);

            //var pesquisa = _pesquisas.Find(e => e.PesquisaId == resposta.PesquisaId);
            var nova_lista = _resposta.Find(e => e.PesquisaId == resposta.PesquisaId).ToList();
            return nova_lista;


         }

        //Inserir varias respostas
        public List<Resposta> InserirVariasRespostas(List<Resposta> respostas)
        {
            _resposta.InsertMany(respostas);
            return respostas;
        }
    }
}   
