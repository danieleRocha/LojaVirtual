using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Modelo
{
    public class Mercadoria : ITipo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataDeCadastramento { get; set; }

        private List<string> cores = new List<string>();

        public IEnumerable<string> Cores
        {
            get { return cores; }
            set { cores = value.ToList(); }
        }

        private List<Foto> fotos = new List<Foto>();

        public IEnumerable<Foto> Fotos
        {
            get { return fotos; }
            set { fotos = value.ToList(); }
        }

        private List<Produto> produtos = new List<Produto>();

        public IEnumerable<Produto> Produtos
        {
            get { return produtos; }
            set { produtos = value.ToList(); }
        }

        public void AdicionarFotos(IEnumerable<Foto> listaDeFotos)
        {
            foreach (var foto in listaDeFotos.Where(foto => fotos.FirstOrDefault(p => p.Id == foto.Id) == null))
            {
                fotos.Add(foto);
            }
        }       
    }
}
