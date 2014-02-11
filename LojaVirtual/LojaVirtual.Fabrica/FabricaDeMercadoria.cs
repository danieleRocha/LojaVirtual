﻿using System;
using System.Collections.Generic;
using System.Web;
using LojaVirtual.Modelo;

namespace LojaVirtual.Fabrica
{
    public class FabricaDeMercadoria
    {
        public static FabricaDeMercadoria Instancia()
        {
            return Inicializadora.instancia;
        }

        private class Inicializadora
        {
            internal static readonly FabricaDeMercadoria instancia = new FabricaDeMercadoria();
        }
        
        public void ObterMercadoria(Mercadoria mercadoria, List<KeyValuePair<string, string>> tamanhos,
                                      List<HttpPostedFileWrapper> arquivos)
        {
            mercadoria.Id = Guid.NewGuid();
            mercadoria.DataDeCadastramento = DateTime.Now;
            mercadoria.Produtos = FabricaDeProduto.Instancia().CriarProdutos(tamanhos);
            mercadoria.Fotos = FabricaDeFoto.Instancia().ObterFotos(arquivos);
        }
    }
}
