using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura
{
    public abstract class ContextoBase :  DbContext, IContexto
    {
        public void Save()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public dynamic Entry(IMap item)
        {
            return base.Entry(item);
        }
    }
}
