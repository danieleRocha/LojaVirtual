using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using LojaVirtual.Apresentacao.Model;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class HomeViewModel
    {
        public static int NumeroDeProdutosEmDestaque
        {
            get { return NProdutosEmDestaque(); }
        }

        public static int NumeroDePropagandas
        {
            get { return NPropagandas(); }
        }

        private static int NPropagandas()
        {
            string nomeDaPasta = ConfigReader.LerNoString(ConfigReader.TagPropagandas, ConfigReader.TagPastaDePropagandas);

            var directoryInfo = new DirectoryInfo(nomeDaPasta);

            return directoryInfo.GetFiles().Count();
        }

        private static int NProdutosEmDestaque()
        {
            string nomeDaPasta = ConfigReader.LerNoString(ConfigReader.TagProdutosEmDestaque, ConfigReader.TagPastaDeProdutosEmDestaque);

            var directoryInfo = new DirectoryInfo(nomeDaPasta);

            return directoryInfo.GetFiles().Count();
        }

        public static string ProdutoEmDestaque(int numero)
        {
            string nomeDaPasta = ConfigReader.LerNoString(ConfigReader.TagProdutosEmDestaque, ConfigReader.TagPastaDeProdutosEmDestaque);

            var directoryInfo = new DirectoryInfo(nomeDaPasta);

            var arquivos = directoryInfo.EnumerateFiles().ToList();

            for (int i = 0; i < arquivos.Count; i++)
            {
                if (i == numero)
                {
                    var stream = new StreamReader(arquivos[i].FullName).BaseStream;
                    var nome = arquivos[i].Name;
                    var tipo = MimeType.GetMimeType(nome);
                    var foto = FabricaDeImagem.Instancia().CriarImagem(nome, tipo, stream);

                    return foto.ConteudoMisto;
                }
            }

            return string.Empty;
        }

        public static string Propagandas(int numero)
        {
            string nomeDaPasta = ConfigReader.LerNoString(ConfigReader.TagPropagandas, ConfigReader.TagPastaDePropagandas);

            var directoryInfo = new DirectoryInfo(nomeDaPasta);

            var arquivos = directoryInfo.EnumerateFiles().ToList();

            for (int i = 0; i < arquivos.Count; i++)
            {
                if (i == numero)
                {
                    var stream = new StreamReader(arquivos[i].FullName).BaseStream;
                    var nome = arquivos[i].Name;
                    var tipo = MimeType.GetMimeType(nome);
                    var foto = FabricaDeImagem.Instancia().CriarImagem(nome, tipo, stream);

                    return foto.ConteudoMisto;
                }
            }

            return string.Empty;
        }
    }
}