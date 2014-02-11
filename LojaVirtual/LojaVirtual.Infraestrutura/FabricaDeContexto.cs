using LojaVirtual.Infraestrutura.Daos;

namespace LojaVirtual.Infraestrutura
{
    public class FabricaDeContexto
    {
        private Contexto contexto;

        private FabricaDeContexto()
        {
            contexto = new Contexto();
        }

        public static FabricaDeContexto Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeContexto instancia = new FabricaDeContexto();
        }


        public Contexto ObterContexto()
        {
            return contexto;
        }
    }
}
