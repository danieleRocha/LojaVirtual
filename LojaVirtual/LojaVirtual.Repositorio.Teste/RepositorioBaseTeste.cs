using System.Collections.Generic;
using LojaVirtual.Apresentacao.Mappers;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaVirtual.Repositorio.Teste
{
    [TestClass]
    public class RepositorioBaseTeste
    {
        [TestInitialize]
        public void Iniciar()
        {
            AutoMapperRegister.RegisterMappings();
        }

        [TestMethod]
        public void ObterTodosTeste()
        {
            var repositorio = new Repositorio<Mercadoria, MercadoriaMap>();
               
            List<Mercadoria> lista = repositorio.ObterTodos();

            Assert.AreNotEqual(lista.Count,0);
        }
    }
}
