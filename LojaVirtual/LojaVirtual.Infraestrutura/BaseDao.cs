using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infraestrutura
{
    public class BaseDao<T>:IDisposable,IDao<T> where T : class
    {
        private Contexto contexto;

        public BaseDao(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            contexto = unitOfWork as Contexto;
        }

        public IQueryable<T> ObterTodos()
        {
            return contexto.Set<T>();
        }

        public T Obter(Guid id)
        {
            return contexto.Set<T>().Find(id);
        }

        public void Adicionar(T item)
        {
            contexto.Set<T>().Add(item);
            contexto.Save();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
