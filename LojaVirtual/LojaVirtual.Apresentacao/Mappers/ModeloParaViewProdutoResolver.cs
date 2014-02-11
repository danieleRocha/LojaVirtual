using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Fabrica;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.Mappers
{
    public class ModeloParaViewProdutoResolver : ValueResolver<Mercadoria, List<KeyValuePair<string, string>>>
    {
        protected override List<KeyValuePair<string, string>> ResolveCore(Mercadoria mercadoria)
        {
            return FabricaDeProduto.Instancia().ObterProdutos(mercadoria.Produtos);
        }
    }
}
