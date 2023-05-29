using Backend_UniFinal.Contextos;
using Backend_UniFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Backend_UniFinal.Dto;

namespace Backend_UniFinal.Repositorios
{
    public class PesquisaRepositorio
    {
        private readonly IMongoCollection<Pesquisa> _pesquisa;
        private readonly IMongoCollection<Resposta> _respostas;


        public PesquisaRepositorio(IOptions<MongoDbContext> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var db = mongoClient.GetDatabase(options.Value.Database);

            _pesquisa = db.GetCollection<Pesquisa>
                (options.Value.PesquisaCollection);

            _respostas = db.GetCollection<Resposta>
                (options.Value.RespostaCollection);

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
        public List<PesquisasDto> pesquisas_por_loja_validade(string lojaId)
        {
            var result = _pesquisa.Find(x => x.Lojas.Contains(lojaId)).ToList();
            DateTime dataAtual = DateTime.UtcNow;
            var validas = result.Where(item => item.DataInicio <= dataAtual && dataAtual <= item.DataFinal).ToList();

            List<PesquisasDto> lista_dto = new List<PesquisasDto>();

            foreach (var item in validas)
            {
                var dtoPesquisa = new PesquisasDto(
                    item.Id,
                    item.Lojas,
                    item.Produtos,
                    item.categoria,
                    item.DataInicio,
                    item.DataFinal,
                    item.nome,
                    item.lojas_concluidas,
                    item.lojas_concorrentes,
                    checar_status(item, lojaId));
                lista_dto.Add(dtoPesquisa);
            }
            return lista_dto;
        }

        // marcar pesquisa como concluida
        public void marcar_como_concluida(string idPesquisa, string idLoja)
        {
            //var alteracao_pesquisa = _pesquisa.Find(e => e.Id == idLoja).FirstOrDefault();
        }


        //checar status de uma pesquisa para cada loja 
        public string checar_status(Pesquisa pesquisa, string IdLoja)
        {

            var respostas_existentes = _respostas.Find(e => e.LojaId == IdLoja).ToList();

            if (pesquisa.lojas_concluidas.Contains(IdLoja))
            {
                return ("concluida");
            }

            if (respostas_existentes != null)
            {

                return ("em_andamento");
            }

            return ("pendente");

        }


        //mudar status de pesquisa
        // public void marcar_como_completa(string idPesquisa, string idloja)
        // {
        //     var pesquisa = _pesquisa.Find(e => e.Id == idPesquisa).FirstOrDefault

        // }

    }




}
