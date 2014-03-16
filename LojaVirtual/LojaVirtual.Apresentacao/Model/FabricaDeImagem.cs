using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.Model
{
    public class FabricaDeImagem
    {
        public static FabricaDeImagem Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeImagem instancia = new FabricaDeImagem();
        }
        
        public List<Imagem> CriarImagens(IEnumerable<Foto> fotos)
        {
            return fotos.Select(foto => new Imagem()
                {
                    Id = foto.Id, Conteudo = "data:image/" + foto.Formato + ";base64," + foto.Conteudo
                }).ToList();
        }
    }
}
