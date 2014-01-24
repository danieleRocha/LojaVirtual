using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio
{
    public interface IRepositorio<T> where T:ITipo 
    {
        List<T> ObterTodos();
        T Obter(Guid id);
    }
}
