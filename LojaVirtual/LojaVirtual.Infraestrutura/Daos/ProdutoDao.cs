using System.Data.Entity;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura.Daos
{
    public class ProdutoDao :BaseDao<ProdutoMap>
    {
        public ProdutoDao(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
