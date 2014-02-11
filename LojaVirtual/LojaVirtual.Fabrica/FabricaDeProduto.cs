using System;
using System.Collections.Generic;
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


        public IEnumerable<Produto> CriarProdutos(List<KeyValuePair<string, string>> tamanhos)
        {
            var produtos = new List<Produto>();

            for (int i = 0; i < tamanhos.Count; i++)
            {
                for (int j = 0; j < Convert.ToInt32(tamanhos[i].Value); j++)
                {
                    produtos.Add(new Produto()
                    {
                        Id = Guid.NewGuid(),
                        Tamanho = tamanhos[i].Key
                    });
                }
            }

            return produtos;
        }

        public List<KeyValuePair<string, string>> ObterProdutos(IEnumerable<Produto> produtos)
        {
            var lista = new List<KeyValuePair<string, string>>();

            foreach (var produto in produtos)
            {
                var key = produto.Tamanho;

                //foreach (var keyvalue in lista)
                //{
                //    if (keyvalue.Key == key)
                //    {
                //        keyvalue = keyvalue.Value + 1;
                //    }
                //}
            }

            return lista;
        }
    }
}
 