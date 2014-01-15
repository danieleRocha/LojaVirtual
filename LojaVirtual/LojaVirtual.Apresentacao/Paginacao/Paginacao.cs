using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Apresentacao.Paginacao
{
    public class Paginacao<T> where T : IOrdenavel 
    {
        public int ItensPorPagina { get; private set; }
        public int TotalDeItens { get; private set; }
        public int PaginaAtual { get; private set; }
        public List<T> Items { get; private set; }
        private List<T> Todos;

        public Paginacao(IEnumerable<T> items, int itensPorPagina)
        {
            ItensPorPagina = itensPorPagina;
            Items = items.ToList();
            Todos = items.ToList();
            TotalDeItens = Items.Count;
            PaginaAtual = 1;
        }

        public void VaParaPagina(int? pagina)
        {
            PaginaAtual = pagina != null ? pagina.Value : 1;
            Items.Clear();
            Items.AddRange(Todos.OrderBy(a => a.Ordem)
                                .Skip((PaginaAtual - 1) * ItensPorPagina)
                                .Take(ItensPorPagina));
        }

        public int TotalDePaginas
        {
            get { return (int)Math.Ceiling((decimal)TotalDeItens / ItensPorPagina); }
        }
    }
}