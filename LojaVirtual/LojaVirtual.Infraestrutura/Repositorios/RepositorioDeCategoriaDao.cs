using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Infraestrutura.Daos;

namespace LojaVirtual.Infraestrutura.Repositorios
{
    public class RepositorioDeCategoriaDao:BaseDao<CategoriaDao>
    {
        IUnitOfWork unitOfWork = new Contexto();

        public RepositorioDeCategoriaDao(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
