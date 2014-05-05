using System.IO;
using System.Xml;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public static class ConfigReader
    {
        private const string NomeDoConfig = @"C:\Users\uqk2\Documents\Meus Documentos\GitHub\LojaVirtual\LojaVirtual\LojaVirtual.Apresentacao\Apresentacao.config";
        public const string TagProdutos = "Produtos";
        public const string TagNumeroDeProdutosPorPagina = "Numero_de_produtos_por_pagina";

        public const string TagCategorias = "Categorias";
        public const string TagNumeroDeCategoriasPorPagina = "Numero_de_categorias_por_pagina";

        public const string TagProdutosEmDestaque = "ProdutosEmDestaque";
        public const string TagPastaDeProdutosEmDestaque = "Pasta_de_produtos_em_destaque";

        public const string TagPropagandas = "Propagandas";
        public const string TagPastaDePropagandas = "Pasta_de_propagandas";


        public static int LerNoInt(string grupo, string tag)
        {
            int valor = 0;

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

        public static string LerNoString(string grupo, string tag)
        {
            string valor = null;

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
                            valor = reader.ReadElementContentAsString();
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