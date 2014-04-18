using System;
using System.Collections.Generic;
using System.Web;
using LojaVirtual.Modelo;

namespace LojaVirtual.Fabrica
{
    public class FabricaDeUsuario
    {
        public static FabricaDeUsuario Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeUsuario instancia = new FabricaDeUsuario();
        }

        public void CriarUsuario(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            usuario.Endereco.Id = Guid.NewGuid();
            foreach (var telefone in usuario.Telefones)
            {
                telefone.Id = Guid.NewGuid();
            }
        }
    }
}
