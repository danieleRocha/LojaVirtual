using System;
using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Infraestrutura.Repositorios;
using LojaVirtual.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaVirtual.Infraestrutura.Teste
{
    [TestClass]
    public class BaseDaoTeste
    {
        [TestMethod]
        public void ObterTeste()
        {
            ProdutoDao produto = new ProdutoDao()
            {
                Id = Guid.NewGuid(),
                Codigo = "AB-215",
                Tamanho = Catalogo.Tamanhos[3]
            };

            BaseDao<ProdutoDao> baseDao = new BaseDao<ProdutoDao>(new Contexto());

            baseDao.Adicionar(produto);

            var produtoObtido = baseDao.Obter(produto.Id);

            Assert.AreEqual(produto, produtoObtido);
        }
    }
}
