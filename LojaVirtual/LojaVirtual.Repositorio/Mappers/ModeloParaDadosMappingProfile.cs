using System;
using AutoMapper;
using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio.Mappers
{
    public class ModeloParaDadosMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Produto, ProdutoMap>();
            Mapper.CreateMap<Mercadoria, MercadoriaMap>();
            Mapper.CreateMap<Mercadoria, MercadoriaMap>().ForMember(dest => dest.Cores, opt => opt.ResolveUsing<MapperResolver>().ConstructedBy(() => new MapperResolver()));
            Mapper.CreateMap<Categoria, CategoriaMap>();
            Mapper.CreateMap<Foto, FotoMap>();
        }
    }
}
