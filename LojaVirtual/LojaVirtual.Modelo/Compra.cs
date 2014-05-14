using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Modelo
{
    public class Compra
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
