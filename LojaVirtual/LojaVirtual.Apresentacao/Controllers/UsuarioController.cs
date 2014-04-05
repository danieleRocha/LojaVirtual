using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaVirtual.Apresentacao.ViewModels;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Cadastrar(string email)
        {
            var usuarioViewModel = new UsuarioViewModel() {Email = email};
            //Todo:Retirar a data de nascimento zerada e continuar o cadastro do usuário...colocando validações!!
            return View(usuarioViewModel);
        }

    }
}
