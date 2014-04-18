using System;
using System.Collections.Generic;
using System.Web;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;
using LojaVirtual.Servico;

namespace LojaVirtual.Fabrica
{
    public class FabricaDeSeguranca
    {
        public static FabricaDeSeguranca Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeSeguranca instancia = new FabricaDeSeguranca();
        }

        private Autenticacao seguranca;
        public Autenticacao Seguranca
        {
            get { return seguranca; }
        }

        public void CriarSeguranca(IRepositorio<Usuario> repositorioDeUsuarios, IRepositorio<Permissao> repositorioDePermissoes)
        {
            throw new NotImplementedException();
        }
    }
}
