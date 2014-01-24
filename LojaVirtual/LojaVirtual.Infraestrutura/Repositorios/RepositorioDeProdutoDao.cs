using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Infraestrutura.Daos;

namespace LojaVirtual.Infraestrutura.Repositorios
{
    public class RepositorioDeProdutoDao:BaseDao<ProdutoDao>
    {
        IUnitOfWork unitOfWork = new Contexto();

        public RepositorioDeProdutoDao(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
