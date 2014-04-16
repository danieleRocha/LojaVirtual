using System;
using LojaVirtual.Apresentacao.Mappers;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaVirtual.Infraestrutura.Teste
{
    [TestClass]
    public class BancoDeDadosTeste
    {
        private BancoDeDados banco;
        private IRepositorio<Permissao> repositorioDePermissoes;

        [TestInitialize]
        public void Iniciar()
        {
            AutoMapperRegister.RegisterMappings();
            banco = new BancoDeDados();
            repositorioDePermissoes = new Repositorio<Permissao, PermissaoMap>();
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
            AdicionarPermissoes();
        }

        [TestMethod]
        public void AdicionarPermissoes()
        {
            repositorioDePermissoes.Adicionar(new Permissao()
                {
                    Id = Guid.NewGuid(),
                    Tipo = Permissao.Tipos.Administrador
                });
            repositorioDePermissoes.Adicionar(new Permissao()
            {
                Id = Guid.NewGuid(),
                Tipo = Permissao.Tipos.Cliente
            });
            repositorioDePermissoes.Adicionar(new Permissao()
            {
                Id = Guid.NewGuid(),
                Tipo = Permissao.Tipos.Gerente
            });
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
            AdicionarPermissoes();
        }
    }
}
