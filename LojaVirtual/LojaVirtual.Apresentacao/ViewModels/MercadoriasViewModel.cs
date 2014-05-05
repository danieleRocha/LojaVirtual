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
        public static string Mercadorias = "Mercadorias";
        public static string Cores = "Cores";
        public static string CategoriasSelecionadas = "Categoria";
        public static int NumeroDeFotosPermitidas = 5;

        private List<Categoria> categoriasDisponiveis;

        public ReadOnlyCollection<Categoria> CategoriasDisponiveis
        {
            get { return categoriasDisponiveis != null ? categoriasDisponiveis.AsReadOnly() : new List<Categoria>().AsReadOnly(); }
        }

        private List<Categoria> todasCategoriasDisponiveis;

        public ReadOnlyCollection<Categoria> TodasCategoriasDisponiveis
        {
            get
            {
                if (todasCategoriasDisponiveis == null)
                {
                    todasCategoriasDisponiveis = new List<Categoria> {new Categoria() {Nome = "Todas as Categorias"}};
                    todasCategoriasDisponiveis.AddRange(CategoriasDisponiveis);
                }
                return todasCategoriasDisponiveis.AsReadOnly();
            }
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

        public MercadoriasViewModel(IEnumerable<Categoria> categoriasDiponiveis)
        {
            this.categoriasDisponiveis = categoriasDiponiveis.ToList();
        }
    }
}