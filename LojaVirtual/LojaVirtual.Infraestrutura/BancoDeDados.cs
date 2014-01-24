
namespace LojaVirtual.Infraestrutura
{
    public class BancoDeDados
    {
        readonly Contexto dataBase;

        public BancoDeDados()
        {
            dataBase = new Contexto();
        }

        public void Criar()
        {
            dataBase.Database.Create();
        }

        public void Excluir()
        {
            dataBase.Database.Delete();
        }
    }
}
