using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Fabrica;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.Mappers
{
    public class ModeloParaViewFotoResolver : ValueResolver<Mercadoria, List<string>>
    {
        protected override List<string> ResolveCore(Mercadoria mercadoria)
        {
            return FabricaDeFoto.Instancia().ObterFotos(mercadoria.Fotos);
        }
    }
}
