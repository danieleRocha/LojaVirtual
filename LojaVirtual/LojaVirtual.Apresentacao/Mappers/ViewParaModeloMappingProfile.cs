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

           var mapperMercadoria = Mapper.CreateMap<MercadoriaViewModel,Mercadoria>();
           mapperMercadoria.ForMember(dest => dest.Fotos, opt => opt.ResolveUsing<ViewParaModeloFotoResolver>().ConstructedBy(() => new ViewParaModeloFotoResolver()));
       }
    }
}
