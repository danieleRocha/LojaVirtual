using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio
{
    public interface IRepositorio<T> where T:class 
    {
        List<T> ObterTodos();
        T Obter(Guid id);
        bool Adicionar(T item);
        bool Excluir(Guid id);
        bool Editar(T item);
    }
}
