using AutoMapper;
using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio.Mappers
{
   public class DadosParaModeloMappingProfile:Profile
    {
       protected override void Configure()
       {
           Mapper.CreateMap<ProdutoMap, Produto>();
           Mapper.CreateMap<MercadoriaMap, Mercadoria>().ForMember(dest => dest.Cores, opt => opt.ResolveUsing<DadosParaModeloResolver>().ConstructedBy(() => new DadosParaModeloResolver()));
           Mapper.CreateMap<CategoriaMap, Categoria>();
           Mapper.CreateMap<FotoMap, Foto>();
       }
       
    }
}
