using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LojaVirtual.Infraestrutura;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio
{
    public class Repositorio<T, TData> : IRepositorio<T>
        where T : ITipo
        where TData : class
    {
        private IDao<TData> dao;
        private IContexto contexto;

        public Repositorio()
        {
            contexto = FabricaDeContexto.Instancia().ObterContexto<TData>();
            dao = FabricaDeDaos.Instancia().ObterDao<TData>(contexto);
        }

        public List<T> ObterTodos()
        {
            IQueryable<TData> todos = dao.ObterTodos();

            IEnumerable<T> lista = Mapper.Map<IEnumerable<TData>, IEnumerable<T>>(todos.ToList());

            return lista.ToList();
        }

        public T Obter(Guid id)
        {
            TData t = dao.Obter(id);

            T item = Mapper.Map<TData, T>(t);

            return item;
        }

        public bool Adicionar(T item)
        {
            TData data = Mapper.Map<T, TData>(item);

            return dao.Adicionar(data);
        }

        public bool Excluir(Guid id)
        {
            return dao.Excluir(id);
        }

        public bool Editar(T item)
        {
            TData data = Mapper.Map<T, TData>(item);

            return dao.Editar(data);
        }
    }
}
