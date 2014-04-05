using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaVirtual.Apresentacao.Helpers;
using LojaVirtual.Apresentacao.ViewModels;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class LoginController : Controller
    {
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
