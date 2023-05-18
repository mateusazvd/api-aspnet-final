namespace Backend_UniFinal.Dto
{
    public class CadastroDtoResposta
    {
        public string PesquisaId { get; set; }
        public string ProdutoId { get; set; }
        public string LojaId { get; set; }

        public double Preco_Regular { get; set; }

        public double Pague_leve { get; set; }

        public double Preco_promo { get; set; }

        public string Url_Imagem { get; set; }
        public string Loja_concorrente { get; set; }
    }
}
