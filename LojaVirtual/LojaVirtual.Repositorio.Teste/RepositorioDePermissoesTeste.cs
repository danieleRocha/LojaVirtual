using System;
using System.Collections.Generic;
using LojaVirtual.Apresentacao.Mappers;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaVirtual.Repositorio.Teste
{
    [TestClass]
    public class RepositorioDePermissoesTeste
    {
        [TestInitialize]
        public void Iniciar()
        {
            AutoMapperRegister.RegisterMappings();
        }

        [TestMethod]
        public void AdicionarUsuario()
        {
            var repositorio = new Repositorio<Permissao, PermissaoMap>();

            bool adicionou = false;

            Endereco endereco = new Endereco()
                {
                 Cep   = "00.111-222",
                 Cidade = "Rio de Janeiro",
                 Complemento = "Ao lado da padaria",
                 Estado = Endereco.Estados.RJ,
                 Id = Guid.NewGuid(),
                 Logradouro = "Rua 1",
                 Numero = "0123"
                };

            List<Telefone> telefones = new List<Telefone>();
            telefones.Add(new Telefone()
                {
                    Ddd = "21",
                    Id = Guid.NewGuid(),
                    Numero = "0123-4523",
                    Tipo = Telefone.TipoDeTelefone.Residencial
                });
            telefones.Add(new Telefone()
                {
                    Ddd = "11",
                    Id = Guid.NewGuid(),
                    Numero = "9123-4523",
                    Tipo = Telefone.TipoDeTelefone.Celular
                });
            Usuario usuario = new Usuario()
                {
                    Cpf = "111.222.333-44",
                    DataDeNascimento = DateTime.Now,
                    Email = "xxx@gmail.com",
                    Endereco = endereco,
                    Id = Guid.NewGuid(),
                    Nome = "Fulano da Silva",
                    Senha = "123Abc",
                    Sexo = Usuario.Sexos.Masculino,
                    Telefones = telefones
                };

            foreach (var permissao in repositorio.ObterTodos())
            {
                if (permissao.Tipo == Permissao.Tipos.Cliente)
                {
                    permissao.AdicionarUsuario(usuario);
                    adicionou = repositorio.Editar(permissao);
                }
            }

            Assert.IsTrue(adicionou);
        }

        [TestMethod]
        public void AdicionarAdministrador()
        {
            var repositorio = new Repositorio<Permissao, PermissaoMap>();

            bool adicionou = false;

            Endereco endereco = new Endereco()
            {
                Cep = "00.111-222",
                Cidade = "Rio de Janeiro",
                Complemento = "Ao lado da padaria",
                Estado = Endereco.Estados.RJ,
                Id = Guid.NewGuid(),
                Logradouro = "Rua 1",
                Numero = "0123"
            };

            List<Telefone> telefones = new List<Telefone>();
            telefones.Add(new Telefone()
            {
                Ddd = "21",
                Id = Guid.NewGuid(),
                Numero = "0123-4523",
                Tipo = Telefone.TipoDeTelefone.Residencial
            });
            telefones.Add(new Telefone()
            {
                Ddd = "11",
                Id = Guid.NewGuid(),
                Numero = "9123-4523",
                Tipo = Telefone.TipoDeTelefone.Celular
            });
            Usuario usuario = new Usuario()
            {
                Cpf = "111.222.333-44",
                DataDeNascimento = DateTime.Now,
                Email = "xyz@gmail.com",
                Endereco = endereco,
                Id = Guid.NewGuid(),
                Nome = "Fulano da Silva",
                Senha = "admin",
                Sexo = Usuario.Sexos.Masculino,
                Telefones = telefones
            };

            foreach (var permissao in repositorio.ObterTodos())
            {
                if (permissao.Tipo == Permissao.Tipos.Administrador)
                {
                    permissao.AdicionarUsuario(usuario);
                    adicionou = repositorio.Editar(permissao);
                }
            }

            Assert.IsTrue(adicionou);
        }

    }
}
