using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace LojaVirtual.Modelo
{
    public class Permissao:ITipo
    {
        public Guid Id { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
