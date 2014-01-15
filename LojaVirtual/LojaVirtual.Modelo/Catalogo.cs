using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Modelo
{
    public class Catalogo
    {
        //Todo: Melhoria futura: Colocar as cores e tamanhos  do catálogo em um xml.
        public static readonly List<string> Cores = new List<string>()
            {
                "Preto",
                "Branco",
                "Vermelho",
                "Azul",
                "Verde",
                "Amarelo",
                "Roxo",
                "Rosa",
                "Lilás",
                "Marfim",
                "Marrom",
                "Dourado",
                "Prata",
                "Cinza",
                "Laranja",
                "Coral",
                "Salmão",
                "Estampado",
                "Listrado",
                "Quadriculado",

            };

        public static readonly List<string> Tamanhos = new List<string>()
            {
                "Único",
                "PP",
                "P",
                "M",
                "G",
                "34",
                "36",
                "38",
                "40",
                "42",
                "44",
                "46",
                "48",
                "50",
            };

    }
}
