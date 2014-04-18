using System;
using System.Collections.Generic;
using System.Web;
using LojaVirtual.Modelo;

namespace LojaVirtual.Fabrica
{
    public class FabricaDeCategoria
    {
        public static FabricaDeCategoria Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeCategoria instancia = new FabricaDeCategoria();
        }

        public void CriarCategoria(Categoria categoria)
        {
            categoria.Id = Guid.NewGuid();
        }
    }
}
