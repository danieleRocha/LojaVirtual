using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio
{
    public class FabricaDeRepositorio
    {
        public static FabricaDeRepositorio Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeRepositorio instancia = new FabricaDeRepositorio();
        }

        public IRepositorio<T> ObterRepositorio<T>() where T:ITipo
        {
            if(typeof(T) == typeof(Produto))
                return (IRepositorio<T>) new RepositorioBase<Produto, ProdutoDao>();

            return null;
        }
    }
}
