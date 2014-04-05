using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaVirtual.Infraestrutura.Teste
{
    [TestClass]
    public class BancoDeDadosTeste
    {
        private BancoDeDados banco;

        [TestInitialize]
        public void Iniciar()
        {
            banco = new BancoDeDados();
        }

        [TestMethod]
        public void Criar()
        {
            banco.CriarBaseDados();
        }

        [TestMethod]
        public void CriarBaseAutenticacao()
        {
            banco.CriarBaseAutenticacao();
        }

        //[TestMethod]
        //public void Excluir()
        //{
        //    banco.Excluir();
        //}

        [TestMethod]
        public void Recriar()
        {
            banco.ExcluirBaseDados();
            banco.CriarBaseDados();
        }

        [TestMethod]
        public void RecriarBaseAutenticacao()
        {
            banco.ExcluirBaseAutenticacao();
            banco.CriarBaseAutenticacao();
        }
    }
}
