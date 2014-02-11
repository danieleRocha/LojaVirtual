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
           Mapper.CreateMap<Mercadoria, MercadoriaViewModel>();
       }
    }
}
