using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Fabrica;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;
using LojaVirtual.Servico;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class UsuarioController : Controller
    {
        private IRepositorio<Usuario> repositorioDeUsuarios;
        private IRepositorio<Permissao> repositorioDePermissoes;
        
        public UsuarioController(IRepositorio<Usuario> repositorioDeUsuarios, IRepositorio<Permissao> repositorioDePermissoes)
        {
            this.repositorioDeUsuarios = repositorioDeUsuarios;
            this.repositorioDePermissoes = repositorioDePermissoes;
            
        }

        public ActionResult Cadastrar(string email)
        {
            var usuarioViewModel = new UsuarioViewModel() {Email = email};
            
            return View(usuarioViewModel);
        }

        [HttpPost]
        public ActionResult Cadastrar(UsuarioViewModel usuarioViewModel)
        {
            string mensagem = "Não foi possível realizar o cadastro. Por favor tente mais tarde.";

            if (Seguranca.Autenticacao.EmailJaFoiCadastrado(usuarioViewModel.Email))
            {
               mensagem = "Este e-mail já foi cadastrado. Por favor informe um novo e-mail.";
                goto errou;
            }
            if (Seguranca.Autenticacao.CpfJaFoiCadastrado(usuarioViewModel.Cpf))
            {
                mensagem = "Este CPF já foi cadastrado. Por favor informe um novo CPF.";
                goto errou;
            }

            if (!ModelState.IsValid)
            {
                ModelState nascimento = null;
                if (ModelState.TryGetValue("DataDeNascimento", out nascimento))
                {
                    if ((nascimento != null) && (nascimento.Errors.Count > 0)&&(nascimento.Errors[0].ErrorMessage.Contains("DataDeNascimento")))
                    {
                        ModelState.Remove("DataDeNascimento");
                        ModelState.AddModelError("DataDeNascimento", "* Data de nascimento inválida.");
                    }
                }
                return View("Cadastrar",usuarioViewModel);
            }
            if (usuarioViewModel.Senha != usuarioViewModel.ConfirmacaoDaSenha)
            {
                ModelState.AddModelError("ConfirmaSenha","* Os campos Senha e Confirmação da Senha devem ser iguais.");
                return View("Cadastrar", usuarioViewModel);
            }

            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);

            FabricaDeUsuario.Instancia().CriarUsuario(usuario);

            bool adicionado = false;

            foreach (var permissao in repositorioDePermissoes.ObterTodos())
            {
                if (permissao.Tipo == Permissao.Tipos.Cliente)
                {
                    permissao.AdicionarUsuario(usuario);
                    adicionado = repositorioDePermissoes.Editar(permissao);
                }
            }

            if (adicionado)
            {
                Seguranca.Autenticacao.AutenticarUsuario(usuario.Email, usuario.Senha);
                return RedirectToAction("Index", "Home");
            }

            errou:
            ViewBag.Errou = true;
            ViewBag.Mensagem = mensagem;
            return View("Cadastrar", usuarioViewModel);
        }

    }
}
