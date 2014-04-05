using System.Data.Entity;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura.Daos
{
    public class UsuarioDao:BaseDao<UsuarioMap>
    {
        public UsuarioDao(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

    }
}
