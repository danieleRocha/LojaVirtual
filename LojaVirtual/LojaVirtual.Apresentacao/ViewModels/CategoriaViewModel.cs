using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LojaVirtual.Apresentacao.Paginacao;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class CategoriaViewModel:IViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        private List<Mercadoria> mercadorias = new List<Mercadoria>(); 
        public List<Mercadoria> Mercadorias
        {
            get { return mercadorias; }
            set { mercadorias = value; }
        }
    }
}