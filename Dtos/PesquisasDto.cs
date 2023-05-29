using System.Collections.Generic;
using Backend_UniFinal.Models;
namespace Backend_UniFinal.Dto
{
    public class PesquisasDto
    {
        public string Id { get; set; }
        public List<string> Lojas { get; set; }
        public List<Produto> Produtos { get; set; }
        public string Categoria { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public string Nome { get; set; }
        public List<string> LojasConcluidas { get; set; }
        public List<string> LojasConcorrentes { get; set; }
        public string Status { get; set; }

        public PesquisasDto(string id, List<string> lojas, List<Produto> produtos, string categoria, DateTime dataInicio, DateTime dataFinal, string nome, List<string> lojasConcluidas, List<string> lojasConcorrentes, string status)
        {
            Id = id;
            Lojas = lojas;
            Produtos = produtos;
            Categoria = categoria;
            DataInicio = dataInicio;
            DataFinal = dataFinal;
            Nome = nome;
            LojasConcluidas = lojasConcluidas;
            LojasConcorrentes = lojasConcorrentes;
            Status = status;
        }
    }
}
