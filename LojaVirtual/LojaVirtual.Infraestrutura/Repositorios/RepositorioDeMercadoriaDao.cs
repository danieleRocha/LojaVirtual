using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Infraestrutura.Daos;

namespace LojaVirtual.Infraestrutura.Repositorios
{
    public class RepositorioDeMercadoriaDao:BaseDao<MercadoriaDao>
    {
        IUnitOfWork unitOfWork = new Contexto();

        public RepositorioDeMercadoriaDao(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
