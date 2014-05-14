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
            Mapper.CreateMap<Mercadoria, MercadoriaMap>().ForMember(dest => dest.Cores, opt => opt.ResolveUsing<ModeloParaDadosMercadoriaResolver>().ConstructedBy(() => new ModeloParaDadosMercadoriaResolver()));
            Mapper.CreateMap<Categoria, CategoriaMap>();
            Mapper.CreateMap<Foto, FotoMap>();
            Mapper.CreateMap<Usuario, UsuarioMap>();
            Mapper.CreateMap<Permissao, PermissaoMap>();
            Mapper.CreateMap<Telefone, TelefoneMap>();
            Mapper.CreateMap<Endereco, EnderecoMap>();
            Mapper.CreateMap<Compra, CompraMap>();
            //Mapper.CreateMap<Permissao, PermissaoMap>().ForMember(dest => dest.Tipo, opt => opt.ResolveUsing<ModeloParaDadosPermissaoResolver>().ConstructedBy(() => new ModeloParaDadosPermissaoResolver()));
        }
    }
}
