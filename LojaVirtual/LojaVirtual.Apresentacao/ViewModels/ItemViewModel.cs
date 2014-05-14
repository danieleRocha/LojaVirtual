using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public MercadoriaViewModel Mercadoria { get; set; }

        public decimal Valor()
        {
            return Math.Round((Quantidade * Produto.Preco),2);
        }
    }
}