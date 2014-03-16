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
    public class ModeloParaViewFotoResolver : ValueResolver<Mercadoria, List<Imagem>>
    {
        protected override List<Imagem> ResolveCore(Mercadoria mercadoria)
        {
            return FabricaDeImagem.Instancia().CriarImagens(mercadoria.Fotos);
        }
    }
}
