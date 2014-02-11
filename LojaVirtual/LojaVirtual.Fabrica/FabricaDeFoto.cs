using System;
using System.Collections.Generic;
using System.Web;
using LojaVirtual.Modelo;

namespace LojaVirtual.Fabrica
{
    public class FabricaDeFoto
    {
        public static FabricaDeFoto Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeFoto instancia = new FabricaDeFoto();
        }
        
        public IEnumerable<Foto> ObterFotos(List<HttpPostedFileWrapper> arquivos)
        {
            var fotos = new List<Foto>();

            for (int i = 0; i < arquivos.Count; i++)
            {
                var binaryData = new Byte[arquivos[i].InputStream.Length];
                arquivos[i].InputStream.Read(binaryData, 0,
                                                                 (int)
                                                                 arquivos[i].InputStream.Length);
                var base64String = Convert.ToBase64String(binaryData, 0, binaryData.Length);

                var foto = new Foto()
                {
                    Id = Guid.NewGuid(),
                    Nome = arquivos[i].FileName,
                    Conteudo = base64String,
                    Tamanho = arquivos[i].ContentLength,
                    Formato = arquivos[i].ContentType
                };
                fotos.Add(foto);
            }

            return fotos;
        }
    }
}
