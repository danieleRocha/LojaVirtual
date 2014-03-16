using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura
{
    public class FabricaDeDaos
    {
        private ProdutoDao ProdutoDao { get; set; }
        private MercadoriaDao MercadoriaDao { get; set; }
        private CategoriaDao CategoriaDao { get; set; }
        private FotoDao FotoDao { get; set; }

        public static FabricaDeDaos Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeDaos instancia = new FabricaDeDaos();
        }

        public IDao<T> ObterDao<T>(Contexto unitOfWork) where T : class
        {
            IDao<T> dao = null;

            if (typeof (T) == typeof (ProdutoMap))
            {
                if(ProdutoDao==null)
                    ProdutoDao = new ProdutoDao(unitOfWork);
                
                dao = (IDao<T>)ProdutoDao;
            }
            else if (typeof (T) == typeof (MercadoriaMap))
            {
                if (MercadoriaDao == null)
                    MercadoriaDao = new MercadoriaDao(unitOfWork);

                dao = (IDao<T>)MercadoriaDao;
            }
            else if (typeof(T) == typeof(CategoriaMap))
            {
                if (CategoriaDao == null)
                    CategoriaDao = new CategoriaDao(unitOfWork);

                dao = (IDao<T>)CategoriaDao;
            }
            else if (typeof(T) == typeof(FotoMap))
            {
                if (FotoDao == null)
                    FotoDao = new FotoDao(unitOfWork);

                dao = (IDao<T>)FotoDao;
            }
            
            return dao;
        }
    }
}
