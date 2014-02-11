using AutoMapper;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.Mappers
{
   public class ViewParaModeloMappingProfile:Profile
    {
       protected override void Configure()
       {
           Mapper.CreateMap<CategoriaViewModel, Categoria>();
           Mapper.CreateMap<MercadoriaViewModel, Mercadoria>();
       }
    }
}
