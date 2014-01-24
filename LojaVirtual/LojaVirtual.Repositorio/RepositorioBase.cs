using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Infraestrutura;
using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio
{
    public class RepositorioBase<T, TData> : IRepositorio<T> where T : ITipo
        where TData : class 
    {
        private Contexto unitOfWork = new Contexto();
        private IDao<TData> dao; 

        public RepositorioBase()
        {         
            dao = new BaseDao<TData>(unitOfWork);
        }

        public List<T> ObterTodos()
        {
            IQueryable<TData> todos = dao.ObterTodos();
            
            
            //Todo:Fazer o Mapper aqui!!!
            
            //IQueryable<T> todosMapeados = 
            //return todosMapeados.ToList();
            return null;
        }

        public T Obter(Guid id)
        {
            return default(T);
        }

        // public void Add(T item)
        //{
        //    _context.Set<T>().Add(item);
        //}
  
        //public void Remove(T item)
        //{
        //    _context.Set<T>().Remove(item);
        //}
  
        //public void Edit(T item)
        //{
        //    _context.Entry(item).State = EntityState.Modified;
        //}



    }
}
