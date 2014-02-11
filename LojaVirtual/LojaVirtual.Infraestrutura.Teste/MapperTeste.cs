using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LojaVirtual.Apresentacao.Mappers;
using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaVirtual.Infraestrutura.Teste
{
    [TestClass]
    public class MapperTeste
    {
        [TestInitialize]
        public void Iniciar()
        {
            AutoMapperRegister.RegisterMappings();
        }

        [TestMethod]
        public void MapearModeloParaDados()
        {
            var mercadoria = new Mercadoria()
                {
                    Cores = new List<string>()
                        {
                            Catalogo.Cores[0],
                            Catalogo.Cores[1],
                            Catalogo.Cores[2]
                        },
                    DataDeCadastramento = DateTime.Now,
                    Descricao = "Descrição da Mercadoria",
                    Id = Guid.NewGuid(),
                    Nome = "Nome da Mercadoria",
                    Preco = 21.99m
                };

            var mercadoriaMap = Mapper.Map<Mercadoria, MercadoriaMap>(mercadoria);

        }

        [TestMethod]
        public void MapearDadosParaModelo()
        {
            var mercadoriaMap = new MercadoriaMap()
            {
                Cores = Catalogo.Cores[0]+";"+Catalogo.Cores[1]+";"+Catalogo.Cores[2],
                DataDeCadastramento = DateTime.Now,
                Descricao = "Descrição da Mercadoria",
                Id = Guid.NewGuid(),
                Nome = "Nome da Mercadoria",
                Preco = 21.99m
            };

            var mercadoria= Mapper.Map<MercadoriaMap, Mercadoria>(mercadoriaMap);

        }
    }
}
