using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        
    }
}
