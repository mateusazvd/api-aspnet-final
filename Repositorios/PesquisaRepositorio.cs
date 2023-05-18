using Backend_UniFinal.Contextos;
using Backend_UniFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Backend_UniFinal.Repositorios
{
    public class PesquisaRepositorio
    {
        private readonly IMongoCollection<Pesquisa> _pesquisa;
        public PesquisaRepositorio(IOptions<MongoDbContext> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var db = mongoClient.GetDatabase(options.Value.Database);

            _pesquisa = db.GetCollection<Pesquisa>
                (options.Value.PesquisaCollection);
        }

        //Cadastrar Nova Pesquisa
        public Pesquisa CadastrarPesquisa(Pesquisa pesquisa)
        {
            try
            {
                _pesquisa.InsertOne(pesquisa);
                return pesquisa;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Pegar todas as pesquisas
        public List<Pesquisa> Pesquisas_get_todas()
        {
            try
            {
                var todas_pesquisas = _pesquisa.Find(_ => true).ToList();
                return todas_pesquisas;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Pegar pesquisa por Id
        public Pesquisa Pesquisas_get_id(string id)
        {
            var result = _pesquisa.Find(e => e.Id == id).FirstOrDefault();
            return result;
        }

        //pegar pesquisas por loja
        public List<Pesquisa> pesquisas_por_loja(string lojaId)
        {
            var result = _pesquisa.Find(x => x.Lojas.Contains(lojaId)).ToList();
            return result;
        }

        //pegar pesquisas dentro do prazo Para a loja
        public List<Pesquisa> pesquisas_por_loja_validade(string lojaId)
        {
            var result = _pesquisa.Find(x => x.Lojas.Contains(lojaId)).ToList();
            DateTime dataAtual = DateTime.UtcNow;
            var validas = result.Where(item => item.DataInicio <= dataAtual && dataAtual <= item.DataFinal).ToList();
            return validas;
        }

    }
}
