using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class CarrinhoController : Controller
    {
        //
        // GET: /Carrinho/

        public ActionResult Carrinho()
        {
            return View();
        }

    }
}
