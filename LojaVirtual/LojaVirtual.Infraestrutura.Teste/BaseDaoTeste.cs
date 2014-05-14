using System;
using System.Linq;
using LojaVirtual.Apresentacao.Model;
using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Infraestrutura.Maps;
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
            ProdutoMap produto = new ProdutoMap()
            {
                Id = Guid.NewGuid(),
                Tamanho = Catalogo.Tamanhos[3]
            };

            BaseDao<ProdutoMap> baseDao = new BaseDao<ProdutoMap>(new Contexto());

            baseDao.Adicionar(produto);

            var produtoObtido = baseDao.Obter(produto.Id);

            Assert.AreEqual(produto, produtoObtido);
        }

        [TestMethod]
        public void ObterTodosTeste()
        {
            BaseDao<ProdutoMap> baseDao = new BaseDao<ProdutoMap>(new Contexto());

            IQueryable<ProdutoMap> lista = baseDao.ObterTodos();
            
            Assert.AreNotEqual(lista.Count(),0);
        }
    }
}
