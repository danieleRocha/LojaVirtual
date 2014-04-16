using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaVirtual.Apresentacao.Helpers;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class LoginController : Controller
    {
        private IRepositorio<Usuario> repositorioDeUsuarios;

        public LoginController(IRepositorio<Usuario> repositorioDeUsuarios)
        {
            this.repositorioDeUsuarios = repositorioDeUsuarios;
        }

        [HttpGet]
        public ActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            ViewBag.Cadastro = false;
            ViewBag.Autenticacao = false;
            return View(loginViewModel);
        }

        [HttpPost, ActionName("Login")]
        [Submit("Cadastrar")]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            ModelState.Remove("Email");
            ModelState.Remove("Senha");
            if (!ModelState.IsValid)
            {
                ViewBag.Cadastro = true;
                ViewBag.Autenticacao = false;
                return View("Login", loginViewModel);
            }

            if (repositorioDeUsuarios.ObterTodos().Any(usuario => usuario.Email == loginViewModel.EmailCadastro))
            {
                ViewBag.Cadastro = false;
                ViewBag.Autenticacao = false;
                ViewBag.Errou = true;
                ViewBag.Mensagem =
                    "Este e-mail já foi cadastrado. Por favor digite o e-mail e a senha nos campos ao lado.";
                return View(loginViewModel);
            }

            return RedirectToAction("Cadastrar","Usuario", new { email = loginViewModel.EmailCadastro });
        }

        [HttpPost, ActionName("Login")]
        [Submit("Autenticar")]
        public ActionResult Autenticar(LoginViewModel loginViewModel)
        {
            ModelState.Remove("EmailCadastro");
            if (!ModelState.IsValid)
            {
                ViewBag.Autenticacao = true;
                ViewBag.Cadastro = false;
                return View("Login", loginViewModel);
            }

            return View();
        }

    }
}
