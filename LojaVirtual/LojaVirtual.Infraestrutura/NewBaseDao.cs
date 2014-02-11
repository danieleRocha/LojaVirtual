using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura
{
    public class NewBaseDao<T> : IDisposable, IDao<T> where T : class,IMap 
    {
        protected Contexto contexto;
        protected IDbSet<T> dataBase;
       
        public NewBaseDao(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");
            
                contexto = unitOfWork as Contexto;
            
            if (contexto == null)
                throw new ArgumentNullException("unitOfWork");

                dataBase = contexto.Set<T>();
        }

        public IQueryable<T> ObterTodos()
        {
            return contexto.Set<T>();
        }

        public T Obter(Guid id)
        {
            return dataBase.Find(id);
        }

        public bool Adicionar(T item)
        {
            try
            {
                dataBase.Add(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Excluir(Guid id)
        {
            try
            {
                var item = dataBase.Find(id);
                var objectState = item as IMap;
                Excluir(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Excluir(T item)
        {
            dataBase.Attach(item);
            dataBase.Remove(item);
        }

        public bool Editar(T item)  
        {
            try
            {
                var existing = dataBase.Find(item.Id);
                ((IObjectContextAdapter)contexto).ObjectContext.Detach(existing);
                contexto.Entry(item).State = EntityState.Modified;
                dataBase.Attach(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
