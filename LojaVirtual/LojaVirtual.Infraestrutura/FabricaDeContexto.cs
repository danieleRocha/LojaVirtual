using LojaVirtual.Infraestrutura.Autenticacao;
using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura
{
    public class FabricaDeContexto
    {
        private Contexto contexto;
        private ContextoAutenticacao contextoAutenticacao;

        private FabricaDeContexto()
        {
            contexto = new Contexto();
            contextoAutenticacao = new ContextoAutenticacao();
        }

        public static FabricaDeContexto Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeContexto instancia = new FabricaDeContexto();
        }

        public IContexto ObterContexto<T>() where T : class
        {
            if ((typeof(T) == typeof(UsuarioMap)) ||
            (typeof(T) == typeof(EnderecoMap)) ||
            (typeof(T) == typeof(TelefoneMap))||
             (typeof(T) == typeof(PermissaoMap)))
            {
                return contextoAutenticacao;
            }

            return contexto;
        }
    }
}
