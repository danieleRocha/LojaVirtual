using System.Data.Entity;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura.Daos
{
    public class MercadoriaDao:BaseDao<MercadoriaMap>
    {
        public MercadoriaDao(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

    }
}
