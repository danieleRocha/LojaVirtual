using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public Imagem CriarImagem(string nome, string formato, string conteudo, string tamanho)
        {
            return new Imagem()
                {
                    Id = Guid.NewGuid(),
                    ConteudoMisto = "data:image/" + formato + ";base64," + conteudo,
                    Conteudo = conteudo,
                    Formato = formato,
                    Nome = nome,
                    Tamanho = Convert.ToInt32(tamanho)
                };
        }

        public List<Imagem> CriarImagens(IEnumerable<Foto> fotos)
        {
            return fotos.Select(foto => new Imagem()
                {
                    Id = foto.Id,
                    ConteudoMisto = "data:image/" + foto.Formato + ";base64," + foto.Conteudo,
                    Conteudo = foto.Conteudo,
                    Formato = foto.Formato,
                    Nome= foto.Nome,
                    Tamanho = foto.Tamanho
                }).ToList();
        }

        public List<Imagem> CriarImagens(List<HttpPostedFileWrapper> arquivos)
        {
            var imagens = new List<Imagem>();

            for (int i = 0; i < arquivos.Count; i++)
            {
                var binaryData = new Byte[arquivos[i].InputStream.Length];
                arquivos[i].InputStream.Read(binaryData, 0,
                                             (int)
                                             arquivos[i].InputStream.Length);
                var base64String = Convert.ToBase64String(binaryData, 0, binaryData.Length);

                var foto = new Imagem()
                {
                    Id = Guid.NewGuid(),
                    ConteudoMisto = "data:image/" + arquivos[i].ContentType + ";base64," + base64String,
                    Nome = arquivos[i].FileName,
                    Conteudo = base64String,
                    Tamanho = arquivos[i].ContentLength,
                    Formato = arquivos[i].ContentType
                };
                imagens.Add(foto);
            }

            return imagens;
        }

        public List<Foto> CriarFotos(List<Imagem> imagens)
        {
            return imagens.Select(foto => new Foto()
            {
                Id = foto.Id,
                Conteudo = foto.Conteudo,
                Formato = foto.Formato,
                Nome = foto.Nome,
                Tamanho = foto.Tamanho
            }).ToList();
        }
    }
}
