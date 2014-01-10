using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaVirtual.Modelo
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        private List<Produto> produtos = new List<Produto>();

        public IEnumerable<Produto> Produtos
        {
            get { return produtos; }
            set { produtos = value.ToList(); }
        }

        public void AdicionarProduto(Produto produto)
        {
            if (produtos.FirstOrDefault(p => p.Id == produto.Id) == null)
                produtos.Add(produto);
        }

        public void RemoverProduto(Produto produto)
        {
            if (produtos.FirstOrDefault(p => p.Id == produto.Id) != null)
                produtos.Remove(produto);
        }

        public void RemoverProduto(Guid idProduto)
        {
            foreach (var produto in Produtos.Where(produto => produto.Id == idProduto))
            {
                produtos.Remove(produto);
                break;
            }
        }

        public void AdicionarProdutos(IEnumerable<Produto> produtosAdicionados)
        {
            foreach (var produto in produtosAdicionados)
            {
                AdicionarProduto(produto);
            }
        }
    }
}
