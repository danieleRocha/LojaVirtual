using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class CompraViewModel
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}