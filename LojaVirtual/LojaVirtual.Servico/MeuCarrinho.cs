using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LojaVirtual.Modelo;

namespace LojaVirtual.Servico
{
    public class MeuCarrinho
    {
        private const string IdCarrinho = "Carrinho";

        private Carrinho carrinho
        {
            get { return (Carrinho) HttpContext.Current.Session[IdCarrinho]; }
        }

        public Carrinho ObterCarrinho()
        {
            if (carrinho != null) return carrinho;

            var usuario = Seguranca.Autenticacao.ObterUsuarioAutenticado();

            if ((usuario != null)&&(usuario.Carrinho!=null)) return usuario.Carrinho;
        
            HttpContext.Current.Session[IdCarrinho] = new Carrinho();

            return carrinho;
        }
    }
}
