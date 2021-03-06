﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infraestrutura
{
    public interface IDao<T> where T:class 
    {
        IQueryable<T> ObterTodos();
        T Obter(Guid id);
        bool Adicionar(T item);
        bool Excluir(Guid id);
        bool Editar(T item);
    }
}
