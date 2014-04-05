using System.Data.Entity;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura.Daos
{
    public class TelefoneDao:BaseDao<TelefoneMap>
    {
        public TelefoneDao(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

    }
}
