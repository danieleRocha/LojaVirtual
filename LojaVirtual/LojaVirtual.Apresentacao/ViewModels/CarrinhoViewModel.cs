using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LojaVirtual.Apresentacao.Model;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class CarrinhoViewModel
    {
        public List<ItemViewModel> Itens { get; set; }

        public decimal ValorTotal()
        {
            return Math.Round(Itens.Sum(iten => iten.Valor()),2);
        }

        public decimal PrecoParcelado()
        {
            int numeroMaximoDeParcelas = ConfigReader.LerNoInt(ConfigReader.TagPrecos, ConfigReader.TagNumeroDeParcelas);

            return Math.Round((ValorTotal() / numeroMaximoDeParcelas), 2);
        }

        internal void DecorarItens(List<Mercadoria> mercadorias)
        {
            foreach (var itemViewModel in Itens)
            {
                foreach (var mercadoria in from mercadoria in mercadorias from produto in mercadoria.Produtos.Where(produto => produto.Id == itemViewModel.Produto.Id) select mercadoria)
                {
                    itemViewModel.Mercadoria = Mapper.Map<Mercadoria,MercadoriaViewModel>(mercadoria);
                }
            }
        }
    }
}