using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio.Mappers
{
    public class DadosParaModeloMercadoriaResolver:ValueResolver<MercadoriaMap,List<string>>
    {
        protected override List<string> ResolveCore(MercadoriaMap mercadoriaMap)
        {
            return mercadoriaMap.Cores.Split(';').ToList();
        }
    }
}
