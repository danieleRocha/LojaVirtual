using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace LojaVirtual.Modelo
{
    public class Foto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public int Tamanho { get; set; }
        public string Formato { get; set; }
    }
}
