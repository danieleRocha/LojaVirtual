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
           Mapper.CreateMap<MercadoriaMap, Mercadoria>().ForMember(dest => dest.Cores, opt => opt.ResolveUsing<DadosParaModeloMercadoriaResolver>().ConstructedBy(() => new DadosParaModeloMercadoriaResolver()));
           Mapper.CreateMap<CategoriaMap, Categoria>();
           Mapper.CreateMap<FotoMap, Foto>();
           Mapper.CreateMap<UsuarioMap, Usuario>();
           Mapper.CreateMap<PermissaoMap, Permissao>();
           Mapper.CreateMap<TelefoneMap, Telefone>();
           Mapper.CreateMap<EnderecoMap, Endereco>();
           Mapper.CreateMap<CompraMap, Compra>();
           //Mapper.CreateMap<PermissaoMap, Permissao>().ForMember(dest => dest.Tipo, opt => opt.ResolveUsing<DadosParaModeloPermissaoResolver>().ConstructedBy(() => new DadosParaModeloPermissaoResolver()));
       }
       
    }
}
