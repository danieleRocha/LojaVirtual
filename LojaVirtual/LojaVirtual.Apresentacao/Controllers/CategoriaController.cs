using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class CategoriaController : Controller
    {
        private IRepositorio<Categoria> Repositorio;

        public CategoriaController(IRepositorio<Categoria> repositorio)
        {
            Repositorio = repositorio;
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            ViewData[CategoriasViewModel.MercadoriasCadastradas] = Repositorio.ObterTodos();

            return View();
        }

    }
}
