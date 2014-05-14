using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio.Mappers
{
    public class DadosParaModeloPermissaoResolver:ValueResolver<string,Permissao.Tipos>
    {
        protected override Permissao.Tipos ResolveCore(string tipo)
        {
            foreach (var tp in Enum.GetValues(typeof(Permissao.Tipos)).Cast<Permissao.Tipos>())
            {
                if (tp.ToString() == tipo)
                    return tp;
            }
            return Permissao.Tipos.Cliente;
        }
    }
}
