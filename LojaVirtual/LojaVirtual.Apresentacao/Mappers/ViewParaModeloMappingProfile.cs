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
           Mapper.CreateMap<UsuarioViewModel, Usuario>();
           Mapper.CreateMap<CarrinhoViewModel, Carrinho>();
           Mapper.CreateMap<ItemViewModel, Item>();
           Mapper.CreateMap<CompraViewModel, Compra>();
           var mapperMercadoria = Mapper.CreateMap<MercadoriaViewModel,Mercadoria>();
           mapperMercadoria.ForMember(dest => dest.Fotos, opt => opt.ResolveUsing<ViewParaModeloFotoResolver>().ConstructedBy(() => new ViewParaModeloFotoResolver()));
       }
    }
}
