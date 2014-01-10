using System.IO;
using System.Xml;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public static class ConfigReader
    {
        private const string NomeDoConfig = @"..\Apresentacao.config";
        public const string TagProdutos = "Produtos";
        public const string TagNumeroDeProdutosPorPagina = "Numero_de_produtos_por_pagina";

        public const string TagCategorias = "Categorias";
        public const string TagNumeroDeCategoriasPorPagina = "Numero_de_categorias_por_pagina";


        public static int? LerNo(string grupo, string tag)
        {
            int? valor = null;

            try
            {

            using (FileStream fileStream = File.OpenRead(NomeDoConfig))
            {
                using (XmlReader reader = XmlReader.Create(fileStream))
                {
                    reader.ReadToFollowing(grupo);
                    while (reader.Read())
                    {
                        if (reader.NodeType != XmlNodeType.Element) continue;
                        if (reader.Name != tag) continue;
                        valor = reader.ReadElementContentAsInt();
                        break;
                    }
                }              
            }
            }
            catch
            {

            }
            return valor;
        }
    }
}