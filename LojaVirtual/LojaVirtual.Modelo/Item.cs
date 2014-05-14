using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Modelo
{
    public class Item
    {
        public Guid Id { get; internal set; }
        public Produto Produto { get; internal set; }
        public int Quantidade { get; set; }
    }
}
