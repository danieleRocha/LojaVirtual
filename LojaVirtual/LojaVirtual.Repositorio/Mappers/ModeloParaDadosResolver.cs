using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio.Mappers
{
    public class MapperResolver:ValueResolver<Mercadoria,string>
    {
        protected override string ResolveCore(Mercadoria source)
        {
            string cores = string.Empty;

            foreach (var cor in source.Cores)
            {
                if (cores == string.Empty)
                    cores = cor;
                else
                    cores = cores + ";" + cor;
            }
            return cores;
        }
    }
}
