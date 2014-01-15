using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaVirtual.Apresentacao.ViewModels;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class MercadoriaController : Controller
    {
        public ActionResult Mercadorias()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            return View();
        }

    }
}
