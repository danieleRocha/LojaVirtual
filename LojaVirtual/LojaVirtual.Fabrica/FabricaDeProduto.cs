using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LojaVirtual.Modelo;

namespace LojaVirtual.Fabrica
{
    public class FabricaDeProduto
    {
        public static FabricaDeProduto Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeProduto instancia = new FabricaDeProduto();
        }
        
        public IEnumerable<Produto> CriarProdutos(List<KeyValuePair<string, string>> tamanhos,decimal preco)
        {
            var produtos = new List<Produto>();

            for (int i = 0; i < tamanhos.Count; i++)
            {
                for (int j = 0; j < Convert.ToInt32(tamanhos[i].Value); j++)
                {
                    produtos.Add(new Produto()
                    {
                        Id = Guid.NewGuid(),
                        Tamanho = tamanhos[i].Key,
                        Preco = preco
                    });
                }
            }

            return produtos;
        }

        public List<KeyValuePair<string, string>> ObterProdutos(IEnumerable<Produto> produtos)
        {
            var dic = new Dictionary<string, int>();

            foreach (var produto in produtos)
            {
                if(dic.ContainsKey(produto.Tamanho))
                {
                    dic[produto.Tamanho]++;
                }
                else
                {
                    dic.Add(produto.Tamanho,1);
                }
            }

            return dic.Keys.Select(key => new KeyValuePair<string, string>(key, dic[key].ToString(CultureInfo.InvariantCulture))).ToList();
        }
    }
}
