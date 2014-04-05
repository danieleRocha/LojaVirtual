using System.Data.Entity;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura.Daos
{
    public class PermissaoDao:BaseDao<PermissaoMap>
    {
        public PermissaoDao(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

    }
}
