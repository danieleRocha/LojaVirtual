using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LojaVirtual.Apresentacao.Model;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class MercadoriaViewModel : IViewModel
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* É necessário preencher o Nome da Mercadoria.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* É necessário preencher o Preço da Mercadoria.")]
        [Range(typeof(decimal), "0,01", "1000000000",ErrorMessage = "* O preço deve ser maior que R$ 0,00.")]
        [Display(Name = "Preço")]
        public decimal? Preco { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* É necessário preencher a Quantidade de Tamanhos.")]
        [Range(typeof(int), "1", "1000000000", ErrorMessage = "* A quantidade de tamanhos deve ser maior que 0.")]
        public int? QuantidadeDeTamanhos { get; set; }

        private List<Imagem> imagens = new List<Imagem>();
        public List<Imagem> Imagens
        {
            get { return imagens; }
            set { imagens = value; }
        }

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

        public List<Produto> Produtos { get; set; }

        private List<KeyValuePair<string, string>> tamanhos = new List<KeyValuePair<string, string>>();
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

        public string TamanhosSelecionados()
        {
            string tamanhosSelecionados = string.Empty;

            for (int j = 0; j < tamanhos.Count; j++)
            {
                for (int i = 0; i < Catalogo.Tamanhos.Count; i++)
                {
                    bool selecionado = tamanhos[j].Key == Catalogo.Tamanhos[i];

                    if (i == 0)
                    {
                        if (selecionado)
                        {
                            tamanhosSelecionados = tamanhosSelecionados + "true";
                        }
                        else
                        {
                            tamanhosSelecionados = tamanhosSelecionados + "false";
                        }
                    }
                    else
                    {
                        if (selecionado)
                        {
                            tamanhosSelecionados = tamanhosSelecionados + "," + "true";
                        }
                        else
                        {
                            tamanhosSelecionados = tamanhosSelecionados + "," + "false";
                        }
                    }
                }
                if (j < tamanhos.Count - 1)
                    tamanhosSelecionados = tamanhosSelecionados + ";";
            }

            return tamanhosSelecionados;
        }

        public string QuantidadeTamanhosSelecionados()
        {
            string quantidadeTamanhosSelecionados = string.Empty;
            for (int j = 0; j < tamanhos.Count; j++)
            {
                if (j == 0)
                {
                    quantidadeTamanhosSelecionados = quantidadeTamanhosSelecionados + tamanhos[j].Value;
                }
                else
                {
                    quantidadeTamanhosSelecionados = quantidadeTamanhosSelecionados + "," + tamanhos[j].Value;
                }
            }
            return quantidadeTamanhosSelecionados;
        }

        public decimal PrecoParcelado()
        {
            int numeroMaximoDeParcelas = ConfigReader.LerNoInt(ConfigReader.TagPrecos, ConfigReader.TagNumeroDeParcelas);

            if (Preco == null)
                return (decimal)Math.Round(0.0,2);

            return Math.Round((decimal) (Preco/numeroMaximoDeParcelas),2);
        }

        public List<string> TamanhosDisponiveis()
        {
            var listaDeTamanhos = new List<string>();

            foreach (var tam in Catalogo.Tamanhos)
            {
                foreach (var produto in Produtos)
                {
                    if((produto.Tamanho==tam)&&(produto.Estado==Produto.EstadoDoProduto.Disponível.ToString())
                        &&(!listaDeTamanhos.Contains(tam)))
                        listaDeTamanhos.Add(tam);
                }
            }

            return listaDeTamanhos;
        }
    }
}