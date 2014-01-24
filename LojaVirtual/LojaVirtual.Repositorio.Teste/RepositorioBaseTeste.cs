using System;
using System.Collections.Generic;
using LojaVirtual.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaVirtual.Repositorio.Teste
{
    [TestClass]
    public class RepositorioBaseTeste
    {
        [TestMethod]
        public void ObterTodosTeste()
        {
            var repositorio = FabricaDeRepositorio.Instancia().ObterRepositorio<Produto>();

            List<Produto> lista = repositorio.ObterTodos();

            Assert.AreNotEqual(lista.Count,0);
        }
    }
}
