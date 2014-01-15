using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using LojaVirtual.Apresentacao.Paginacao;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class MercadoriasViewModel
    {
        public List<Mercadoria> Mercadorias { get; set; }

        private static List<Categoria> categoriasDisponiveis;

        public static ReadOnlyCollection<Categoria> CategoriasDisponiveis
        {
            get { return categoriasDisponiveis != null ? categoriasDisponiveis.AsReadOnly() : new List<Categoria>().AsReadOnly(); }
        }

        public static string TamanhosDisponiveis
        {
            get { return ObterTamanhosDisponiveis(); }
        }

        private static string ObterTamanhosDisponiveis()
        {
            string tamanhos = string.Empty;

            for (int i = 0; i < Catalogo.Tamanhos.Count; i++)
            {
                if (i == 0)
                    tamanhos = tamanhos + Catalogo.Tamanhos[i];
                else
                    tamanhos = tamanhos + "," + Catalogo.Tamanhos[i];
            }

            return tamanhos;
        }

        public MercadoriasViewModel(IEnumerable<Mercadoria> mercadorias, IEnumerable<Categoria> categorias)
        {
            categoriasDisponiveis = categorias.ToList();
            Mercadorias = mercadorias.ToList();
        }
    }
}