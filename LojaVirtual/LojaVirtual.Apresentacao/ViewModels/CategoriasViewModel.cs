using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Apresentacao.Paginacao;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class CategoriasViewModel
    {
        public List<Categoria> Categorias{ get; set; }

        public CategoriasViewModel(IEnumerable<Categoria> categorias)
        {
            Categorias = categorias.ToList();
        }

        public const string MercadoriasCadastradas = "MercadoriasCadastradas";
    }
}