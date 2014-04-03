using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVirtual.Apresentacao.Model
{
    public class Imagem
    {
        public Guid Id { get; set; }
        public string ConteudoMisto { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public int Tamanho { get; set; }
        public string Formato { get; set; }
    }
}