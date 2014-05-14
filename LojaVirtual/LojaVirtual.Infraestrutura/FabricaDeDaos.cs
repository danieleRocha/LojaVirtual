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
        private TelefoneDao TelefoneDao { get; set; }
        private UsuarioDao UsuarioDao { get; set; }
        private EnderecoDao EnderecoDao { get; set; }
        private PermissaoDao PermissaoDao { get; set; }
        private CompraDao CompraDao { get; set; }

        public static FabricaDeDaos Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeDaos instancia = new FabricaDeDaos();
        }

        public IDao<T> ObterDao<T>(IContexto unitOfWork) where T : class
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
            else if (typeof(T) == typeof(UsuarioMap))
            {
                if (UsuarioDao == null)
                    UsuarioDao = new UsuarioDao(unitOfWork);

                dao = (IDao<T>)UsuarioDao;
            }
            else if (typeof(T) == typeof(TelefoneMap))
            {
                if (TelefoneDao == null)
                    TelefoneDao = new TelefoneDao(unitOfWork);

                dao = (IDao<T>)TelefoneDao;
            }
            else if (typeof(T) == typeof(EnderecoMap))
            {
                if (EnderecoDao == null)
                    EnderecoDao = new EnderecoDao(unitOfWork);

                dao = (IDao<T>)EnderecoDao;
            }
            else if (typeof(T) == typeof(PermissaoMap))
            {
                if (PermissaoDao == null)
                    PermissaoDao = new PermissaoDao(unitOfWork);

                dao = (IDao<T>)PermissaoDao;
            }
            else if (typeof(T) == typeof(CompraMap))
            {
                if (CompraDao == null)
                    CompraDao = new CompraDao(unitOfWork);

                dao = (IDao<T>)CompraDao;
            }
            
            return dao;
        }
    }
}
