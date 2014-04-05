
using LojaVirtual.Infraestrutura.Autenticacao;

namespace LojaVirtual.Infraestrutura
{
    public class BancoDeDados
    {
        readonly Contexto baseDados;
        private readonly ContextoAutenticacao baseAutenticacao;

        public BancoDeDados()
        {
            baseDados = new Contexto();
            baseAutenticacao = new ContextoAutenticacao();
        }

        public void CriarBaseDados()
        {
            baseDados.Database.Create();
        }

        public void ExcluirBaseDados()
        {
            baseDados.Database.Delete();
        }

        public void CriarBaseAutenticacao()
        {
            baseAutenticacao.Database.Create();
        }

        public void ExcluirBaseAutenticacao()
        {
            baseAutenticacao.Database.Delete();
        }
    }
}
