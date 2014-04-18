using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaVirtual.Fabrica;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;
using LojaVirtual.Servico;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        private ISeguranca seguranca;

        public HomeController(ISeguranca seguranca)
        {
            this.seguranca = seguranca;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NaoAutorizado()
        {
            return View("NaoAutorizado");
        }

        [FiltroSeguranca(Roles = "Gerente,Administrador")]
        public ActionResult BarraMenu()
        {
            return View();
        }
    }
}
