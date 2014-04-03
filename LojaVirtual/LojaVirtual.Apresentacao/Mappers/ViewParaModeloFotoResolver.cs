using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LojaVirtual.Apresentacao.Model;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Fabrica;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.Mappers
{
    public class ViewParaModeloFotoResolver : ValueResolver<MercadoriaViewModel, List<Foto>>
    {
        protected override List<Foto> ResolveCore(MercadoriaViewModel mercadoria)
        {
            return FabricaDeImagem.Instancia().CriarFotos(mercadoria.Imagens);
        }
    }
}
