using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class MercadoriaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<string> Cores { get; set; }
        public int NumeroDeTamanhos { get; set; }
        public List<KeyValuePair<string, string>> Tamanhos { get; set; }
        public List<Foto> Fotos { get; set; } 

    }
}