using Backend_UniFinal.Models;
using Backend_UniFinal.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Backend_UniFinal.Controllers
{
    [ApiController]
    [Route("/api/pesquisa")]
    public class PesquisaController: ControllerBase
    {
        private readonly PesquisaRepositorio _pesquisaRepositorio;

        public PesquisaController(PesquisaRepositorio pesquisaRepositorio)
        {
            _pesquisaRepositorio = pesquisaRepositorio; 
        }

        // CADASTRO DE PESQUISA
        [HttpPost("cadastro")]
        public ActionResult Cadastro(Pesquisa pesquisa)
        {
            try
            {
                var response = _pesquisaRepositorio.CadastrarPesquisa(pesquisa);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PEGAR TODAS AS PESQUISAS
        [HttpGet("todos")]
        public ActionResult todos()
        {
            try
            {
                var result = _pesquisaRepositorio.Pesquisas_get_todas();
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(new { erro = true, message = "Erro interno, tente novamente mais tarde :(" });
            }
        }

        //PEGAR AS PESQUISAS POR ID
        [HttpGet("{id}")]
        public ActionResult PegarPorId(string id) 
        {
            try
            {
                var result = _pesquisaRepositorio.Pesquisas_get_id(id);
                if (result == null)
                {
                    BadRequest(new {erro = true, message="Não foi possivel encontrar uma pesquisa com esse id :("});
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new {erro = true, message = "Erro interno, tente novamente mais tarde :("});
            }
        }

        //PEGAR PESQUISAS POR LOJA
        [HttpGet("/loja/todas/{lojaId}")]
        public ActionResult PesquisasPorLoja(string lojaId)
        {
            try
            {
                var result = _pesquisaRepositorio.pesquisas_por_loja(lojaId);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(new { erro = true, message = "Erro interno, tente novamente mais tarde :(" });
            }
        }

        //PEGAR PESQUISAS VALIDAS POR LOJA
        [HttpGet("/loja/{lojaId}")]
        public ActionResult PesquisasPorLojaValidas(string lojaId)
        {
            try
            {
                var result = _pesquisaRepositorio.pesquisas_por_loja_validade(lojaId);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(new { erro = true, message = "Erro interno, tente novamente mais tarde :(" });
            }
        }

        [HttpPost("/loja/concluir/{idPesquisa}/{idloja}")]
        public ActionResult MarcarComoConcluida(string idPesquisa, string idloja){
            try
            {
                var teste = _pesquisaRepositorio.marcar_como_completa(idPesquisa,idloja);
                return Ok(teste);
            }
            catch (System.Exception)
            {
                
                return BadRequest();
            }
        }
    



    }
}
