using Backend_UniFinal.Models;
using Backend_UniFinal.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Backend_UniFinal.Controllers
{
    [ApiController]
    [Route("/api/resposta")]
    public class RespostaController : ControllerBase
    {
        private readonly RespostaRepositorio _respostaRepositorio;

        public RespostaController(RespostaRepositorio respostaRepositorio)
        {
            _respostaRepositorio = respostaRepositorio;
        }

        //Cadastrar Resposta
        [HttpPost("/cadastro")]
        public ActionResult cadastroResposta(Resposta resposta)
        {
            try
            {
                var result = _respostaRepositorio.CadastroResposta(resposta);
                return Ok(result);

            }
            catch (Exception)
            {

                return BadRequest(new { erro = true, message = "Não foi possivel concluir o cadastro" });
            }

        }

        //INSERIR VARIAS RESPOSTAS
        [HttpPost("/cadastrarVarias")]
        public ActionResult inserirVariasRespostas(List<Resposta> respostas)
        {
            try
            {
                var result = _respostaRepositorio.InserirVariasRespostas(respostas);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(new { erro = true, message = "Erro ao Salvar Respostas" });

            }
        }   

        // Pegar todas as respostas
        [HttpGet("todos")]
        public ActionResult PegarTodasRespostas()
        {
            try
            {
                var result = _respostaRepositorio.Respostas_get_todas();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { erro = true, message = "Erro ao Procurar as Respostas" });

            }
        }

        //Pegar resposta por Id de Pesquisa
        [HttpGet("{pesquisaId}")]
        public ActionResult PegarRespostaPesquisa(string pesquisaId)
        {
            try
            {
                var result = _respostaRepositorio.Respostas_por_pesquisa(pesquisaId);
                return Ok(result);

            }
            catch (Exception)
            {

                return BadRequest(new { erro = true, message = "Não foi possivel Encontrar Respostas para a pesquisa " + pesquisaId });

            }
        }

        //Pegar resposta por Pesquisa e por Loja
        [HttpGet("{pesquisaId}/{lojaId}")]
        public ActionResult pegarRespostaPesquisaLoja(string pesquisaId, string lojaId)
        {
            try
            {
                var result = _respostaRepositorio.Resposta_por_loja(pesquisaId, lojaId);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(new { erro = true, message = "não foi possivel encontrar respostas" });
            }
        }

        //DELETAR RESPOSTA
        [HttpDelete("{id}")]
        public ActionResult deletarResposta(string id)
        {
            try
            {
                _respostaRepositorio.ApagarResposta(id);
                return Ok(new { erro = false, message = "Pesquisa {id} deletada com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { erro = true, message = "Erro ao deletar a Resposta" });
            }
        }

    }
}
