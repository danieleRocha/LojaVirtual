using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Servico
{
    public class Servico<T> : IServico<T>where T : class 
    {
        public Servico()
        {
            
        }
    }
}
