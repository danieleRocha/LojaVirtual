using System.Data.Entity;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura.Daos
{
    public class CompraDao:BaseDao<CompraMap>
    {
        public CompraDao(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

    }
}
