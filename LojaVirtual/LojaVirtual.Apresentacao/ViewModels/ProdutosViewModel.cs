using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class ProdutosViewModel:BaseViewModel
    {
        public List<Produto> Produtos { get; set; }

        private static List<Categoria> categoriasDisponiveis; 
        public static ReadOnlyCollection<Categoria> CategoriasDisponiveis
        {
            get {return categoriasDisponiveis != null ? categoriasDisponiveis.AsReadOnly() : new List<Categoria>().AsReadOnly();}
        }

        public static readonly List<string> Cores = new List<string>()
        {
            "Preto",
            "Branco",
            "Vermelho",
            "Azul",
            "Verde",
            "Amarelo",
            "Roxo",
            "Rosa",
            "Lilás",
            "Marfim",
            "Marrom",
            "Dourado",
            "Prata",
            "Cinza",
            "Laranja",
            "Coral",
            "Salmão",
            "Estampado",
            "Listrado",
            "Quadriculado",

        };
        
        private int numeroDeProdutosPorPagina;
        private int NumeroDeProdutosPorPagina
        {
            get
            {
                if (numeroDeProdutosPorPagina == 0)
                {
                    var valorConfig = ConfigReader.LerNo(ConfigReader.TagProdutos,
                                                                 ConfigReader.TagNumeroDeProdutosPorPagina);
                    if (valorConfig != null) numeroDeProdutosPorPagina = (int) valorConfig;
                    else numeroDeProdutosPorPagina = 5;
                }
                return numeroDeProdutosPorPagina;
            }
        }

        public ProdutosViewModel(IEnumerable<Produto> produtos,IEnumerable<Categoria> categorias)
        {
            categoriasDisponiveis = categorias.ToList();
            Produtos = produtos.ToList();
            InformacaoDePaginacao = new InformacaoDePaginacao(Produtos.Count,NumeroDeProdutosPorPagina,1);
        }
    }
}