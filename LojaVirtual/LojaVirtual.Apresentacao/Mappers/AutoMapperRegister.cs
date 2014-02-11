using AutoMapper;
using LojaVirtual.Repositorio;
using LojaVirtual.Repositorio.Mappers;

namespace LojaVirtual.Apresentacao.Mappers
{
    public class AutoMapperRegister
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
                {
                    x.AddProfile<ModeloParaViewMappingProfile>();
                    x.AddProfile<ViewParaModeloMappingProfile>();
                    x.AddProfile<ModeloParaDadosMappingProfile>();
                    x.AddProfile<DadosParaModeloMappingProfile>();
                });
        }
    }

    
}
