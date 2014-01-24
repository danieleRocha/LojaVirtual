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
        private IRepositorio<Categoria> repositorioDeCategorias;
        private IRepositorio<Mercadoria> repositorioDeMercadorias;

        public CategoriaController(IRepositorio<Categoria> repositorioDeCategorias, IRepositorio<Mercadoria> repositorioDeMercadorias)
        {
            this.repositorioDeCategorias = repositorioDeCategorias;
            this.repositorioDeMercadorias = repositorioDeMercadorias;
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            ViewData[CategoriasViewModel.MercadoriasCadastradas] = repositorioDeMercadorias.ObterTodos();

            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(CategoriaViewModel categoriaViewModel, FormCollection form)
        {
            var ids = form[CategoriasViewModel.MercadoriasSelecionadas].Split(',');
            categoriaViewModel.Mercadorias.Clear();

            //foreach (var id in ids)
            //    {
            //    var mercadoria = 
            //        categoriaViewModel.Mercadorias.Add(repositorioDeMercadorias.Obter(Guid.Parse(id)));
            //    }
            
            return View();
        }
    }
}
