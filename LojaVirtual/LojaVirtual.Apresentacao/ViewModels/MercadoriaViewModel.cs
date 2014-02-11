using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class MercadoriaViewModel:IViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        public int NumeroDeTamanhos { get; set; }
        
        private List<Categoria> categorias = new List<Categoria>(); 
        public List<Categoria> Categorias
        {
            get { return categorias; }
            set { categorias = value; }
        }

        private List<string> cores = new List<string>();
        public List<string> Cores
        {
            get { return cores; }
            set { cores = value; }
        }

        private List<KeyValuePair<string, string>> tamanhos  = new List<KeyValuePair<string, string>>();
        public List<KeyValuePair<string, string>> Tamanhos
        {
            get { return tamanhos; }
            set { tamanhos = value; }
        }

        private List<HttpPostedFileWrapper> arquivos = new List<HttpPostedFileWrapper>();
        public List<HttpPostedFileWrapper> Arquivos
        {
            get { return arquivos; }
            set { arquivos = value; }
        }


    }
}