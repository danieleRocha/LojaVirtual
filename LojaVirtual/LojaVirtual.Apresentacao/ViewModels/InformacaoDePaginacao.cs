using System;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class InformacaoDePaginacao
    {       
        public int TotalDeItens { get; set; }
        public int ItensPorPagina { get; set; }
        public int PaginaAtual { get; set; }

        public int TotalDePaginas
        {
            get { return (int)Math.Ceiling((decimal)TotalDeItens / ItensPorPagina); }
        }

        public InformacaoDePaginacao(int totalDeItens, int itensPorPagina, int paginaAtual)
        {         
            TotalDeItens = totalDeItens;
            ItensPorPagina = itensPorPagina;
            PaginaAtual = paginaAtual;
        }
    }
}