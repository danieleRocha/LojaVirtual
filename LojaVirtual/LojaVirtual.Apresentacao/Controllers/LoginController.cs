using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaVirtual.Apresentacao.Helpers;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;
using LojaVirtual.Servico;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class LoginController : Controller
    {
        private IRepositorio<Usuario> repositorioDeUsuarios;
        private IRepositorio<Categoria> repositorioDeCategorias;

        public LoginController(IRepositorio<Usuario> repositorioDeUsuarios, IRepositorio<Categoria> repositorioDeCategorias)
        {
            this.repositorioDeUsuarios = repositorioDeUsuarios;
            this.repositorioDeCategorias = repositorioDeCategorias;
        }

        [HttpGet]
        public ActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            ViewBag.Cadastro = false;
            ViewBag.Autenticacao = false;
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            return View(loginViewModel);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Seguranca.Autenticacao.InvalidarUsuario();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Login")]
        [Submit("Cadastrar")]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
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

            return RedirectToAction("Cadastrar", "Usuario", new { email = loginViewModel.EmailCadastro });
        }

        [HttpPost, ActionName("Login")]
        [Submit("Autenticar")]
        public ActionResult Autenticar(LoginViewModel loginViewModel)
        {
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            ModelState.Remove("EmailCadastro");
            if (!ModelState.IsValid)
            {
                ViewBag.Autenticacao = true;
                ViewBag.Cadastro = false;
                return View("Login", loginViewModel);
            }

            if (!Seguranca.Autenticacao.EmailJaFoiCadastrado(loginViewModel.Email))
            {
                ViewBag.Cadastro = false;
                ViewBag.Autenticacao = false;
                ViewBag.Errou = true;
                ViewBag.Mensagem =
                    "Este e-mail ainda não foi cadastrado. Por favor cadastre-se digitando o e-mail no campo ao lado.";
                return View(loginViewModel);
            }

            if (!Seguranca.Autenticacao.AutenticarUsuario(loginViewModel.Email, loginViewModel.Senha))
            {
                ViewBag.Cadastro = false;
                ViewBag.Autenticacao = false;
                ViewBag.Errou = true;
                ViewBag.Mensagem =
                    "A senha está incorreta. Por favor tente novamente ou clique no link \"Esqueceu sua senha?\"";
                return View(loginViewModel);
            }

            Seguranca.Autenticacao.AutenticarUsuario(loginViewModel.Email, loginViewModel.Senha);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Login")]
        [Submit("RecuperarEmail")]
        public ActionResult RecuperarEmail(LoginViewModel loginViewModel)
        {
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            ModelState.Remove("Email");
            ModelState.Remove("Senha");
            ModelState.Remove("EmailCadastro");

            loginViewModel.Email = Seguranca.Autenticacao.ObterEmailAPartirDoCpf(loginViewModel.Cpf);

            if (loginViewModel.Email != null)
            {
                ViewBag.Autenticacao = true;
                ViewBag.Cadastro = false;
                return View("Login", loginViewModel);
            }

            ViewBag.Cadastro = false;
            ViewBag.Autenticacao = false;
            ViewBag.Errou = true;
            ViewBag.Mensagem =
                "Este CPF ainda não foi cadastrado. Por favor cadastre-se digitando o e-mail no campo ao lado.";
            return View(loginViewModel);

        }

        [HttpPost, ActionName("Login")]
        [Submit("RecuperarSenha")]
        public ActionResult RecuperarSenha(LoginViewModel loginViewModel)
        {
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            ModelState.Remove("Email");
            ModelState.Remove("Senha");
            ModelState.Remove("EmailCadastro");

            string msgErro = string.Empty;

            bool usuarioExiste = Seguranca.Autenticacao.EmailJaFoiCadastrado(loginViewModel.Email);

            if (!usuarioExiste)
            {
                msgErro =
                    "Este e-mail ainda não foi cadastrado. Por favor cadastre-se digitando o e-mail no campo ao lado.";
                goto erro;
            }

            bool enviado = Seguranca.Autenticacao.EnviarSenhaPorEmail(loginViewModel.Email);

            if (enviado)
            {
                ViewBag.Autenticacao = true;
                ViewBag.Cadastro = false;
                ViewBag.RecuperouSenha = true;
                return View("Login", loginViewModel);
            }

            msgErro = "Não foi possível enviar a senha. Por favor tente mais tarde.";

        erro:
            ViewBag.Cadastro = false;
            ViewBag.Autenticacao = false;
            ViewBag.Errou = true;
            ViewBag.Mensagem = msgErro;
            return View(loginViewModel);

        }
    }
}
