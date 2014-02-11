using System.Data.Entity;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura.Daos
{
    public class CategoriaDao:BaseDao<CategoriaMap>
    {
        public CategoriaDao(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

    }
}
