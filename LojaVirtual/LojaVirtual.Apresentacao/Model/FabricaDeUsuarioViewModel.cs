using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Servico;

namespace LojaVirtual.Apresentacao.Model
{
    public class FabricaDeUsuarioViewModel
    {
        public static FabricaDeUsuarioViewModel Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeUsuarioViewModel instancia = new FabricaDeUsuarioViewModel();
        }

        public UsuarioViewModel CriarUsuarioViewModel(string email)
        {
            var usuarioViewModel = new UsuarioViewModel
                {
                    Email = email,
                    Carrinho = Compras.MeuCarrinho.ObterCarrinho()
                };

            return usuarioViewModel;
        }
    }
}