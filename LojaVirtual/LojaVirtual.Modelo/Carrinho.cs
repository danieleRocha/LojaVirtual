using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaVirtual.Modelo
{
    public class Carrinho
    {
        private List<Item> itens = new List<Item>();
        public IEnumerable<Item> Itens
        {
            get { return itens; }
            set { itens = value.ToList(); }
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            itens.Add(new Item(){Id = Guid.NewGuid(),Produto = produto,Quantidade = quantidade});
        }

        public void RemoverItem(Guid id)
        {
            itens.RemoveAll(item => item.Id == id);
        }

        public void RemoverTudo()
        {
            itens.Clear();
        }

    }
}
