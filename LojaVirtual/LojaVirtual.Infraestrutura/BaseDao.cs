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
    public class BaseDao<T> : IDisposable, IDao<T> where T : class,IMap
    {
        protected Contexto contexto;
        protected IDbSet<T> dataBase;

        public BaseDao(IUnitOfWork unitOfWork)
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
            return dataBase;
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
                contexto.Save();
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
                var item = Obter(id);
                if (item == null)
                    return false;

                item.RemoverDependencias(contexto);
                dataBase.Remove(item);
                contexto.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Editar(T item)
        {
            try
            {
                var entry = contexto.Entry(item);

                if (entry.State == EntityState.Detached)
                {
                    var currentEntry = dataBase.Find(item.Id);
                    if (currentEntry != null)
                    {
                        var attachedEntry = contexto.Entry(currentEntry);
                        attachedEntry.CurrentValues.SetValues(item);
                        item.Atualizar(contexto);
                    }
                    else
                    {
                        dataBase.Attach(item);
                        entry.State = EntityState.Modified;
                    }
                }
                contexto.SaveChanges();
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
