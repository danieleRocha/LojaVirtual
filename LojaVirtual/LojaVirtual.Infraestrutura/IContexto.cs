using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura
{
    public interface IContexto : IUnitOfWork
    {
        IDbSet<T> Set<T>() where T : class;
        dynamic Entry(IMap item);
        void Dispose();
    }
}
