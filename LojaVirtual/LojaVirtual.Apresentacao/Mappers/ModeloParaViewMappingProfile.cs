using AutoMapper;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.Mappers
{
   public class ModeloParaViewMappingProfile:Profile
    {
       protected override void Configure()
       {
           Mapper.CreateMap<Categoria, CategoriaViewModel>();
           Mapper.CreateMap<Usuario, UsuarioViewModel>();
           var mapperMercadoria = Mapper.CreateMap<Mercadoria, MercadoriaViewModel>();
           mapperMercadoria.ForMember(dest => dest.Tamanhos, opt => opt.ResolveUsing<ModeloParaViewProdutoResolver>().ConstructedBy(() => new ModeloParaViewProdutoResolver()));
           mapperMercadoria.ForMember(dest => dest.Imagens, opt => opt.ResolveUsing<ModeloParaViewFotoResolver>().ConstructedBy(() => new ModeloParaViewFotoResolver()));
       }
    }
}
