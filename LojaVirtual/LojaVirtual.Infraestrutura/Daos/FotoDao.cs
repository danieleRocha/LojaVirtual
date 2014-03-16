using System.Data.Entity;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura.Daos
{
    public class FotoDao :BaseDao<FotoMap>
    {
        public FotoDao(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
