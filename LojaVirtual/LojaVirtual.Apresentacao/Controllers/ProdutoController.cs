using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Produtos()
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
