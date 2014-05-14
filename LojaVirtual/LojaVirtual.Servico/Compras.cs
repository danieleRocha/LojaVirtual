using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Servico
{
    public class Compras:ICompras
    {
        private static MeuCarrinho meuCarrinho;

        public static MeuCarrinho MeuCarrinho
        {
            get
            {
                if (meuCarrinho == null)
                    meuCarrinho = new MeuCarrinho();
                return meuCarrinho;
            }
        }
    }
}
