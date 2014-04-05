using System.Data.Entity;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura.Daos
{
    public class EnderecoDao:BaseDao<EnderecoMap>
    {
        public EnderecoDao(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

    }
}
