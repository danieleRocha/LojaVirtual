using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class CategoriasViewModel:BaseViewModel
    {
        public List<Produto> Categorias{ get; set; }

        private int numeroDeCategoriasPorPagina;
        private int NumeroDeCategoriasPorPagina
        {
            get
            {
                if (numeroDeCategoriasPorPagina == 0)
                {
                    var valorConfig = ConfigReader.LerNo(ConfigReader.TagCategorias,
                                                                 ConfigReader.TagNumeroDeCategoriasPorPagina);
                    if (valorConfig != null) numeroDeCategoriasPorPagina = (int) valorConfig;
                    else numeroDeCategoriasPorPagina = 5;
                }
                return numeroDeCategoriasPorPagina;
            }
        }

        public CategoriasViewModel(IEnumerable<Produto> categorias)
        {
            Categorias = categorias.ToList();
            InformacaoDePaginacao = new InformacaoDePaginacao(Categorias.Count,NumeroDeCategoriasPorPagina,1);
        }
    }
}