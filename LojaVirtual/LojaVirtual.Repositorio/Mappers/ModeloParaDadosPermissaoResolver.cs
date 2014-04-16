using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio.Mappers
{
    public class ModeloParaDadosPermissaoResolver:ValueResolver<Permissao.Tipos,string>
    {
        protected override string ResolveCore(Permissao.Tipos source)
        {
            return source.ToString();
        }
    }
}
