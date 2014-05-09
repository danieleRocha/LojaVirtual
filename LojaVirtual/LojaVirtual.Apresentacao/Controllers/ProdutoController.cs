using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class ProdutoController : Controller
    {
        private IRepositorio<Mercadoria> repositorioDeMercadorias;
        private IRepositorio<Categoria> repositorioDeCategorias;

        public ProdutoController(IRepositorio<Mercadoria> repositorioDeMercadorias, IRepositorio<Categoria> repositorioDeCategorias)
        {
            this.repositorioDeMercadorias = repositorioDeMercadorias;
            this.repositorioDeCategorias = repositorioDeCategorias;
        }

        [HttpGet]
        public ActionResult Produto(Guid id)
        {
            var mercadoria = repositorioDeMercadorias.Obter(id);
            var mercadoriaViewModel = Mapper.Map<Mercadoria, MercadoriaViewModel>(mercadoria);

            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            return View(mercadoriaViewModel);
        }

        [HttpPost]
        public ActionResult Produto(MercadoriaViewModel mercadoriaViewModel, FormCollection form)
        {
            var mercadoria = repositorioDeMercadorias.Obter(mercadoriaViewModel.Id);
            var merViewModel = Mapper.Map<Mercadoria, MercadoriaViewModel>(mercadoria);

            if ((merViewModel.TamanhosDisponiveis().Count > 1)&&(form["TamanhoEscolhido"]=="nenhum"))
            {
                ViewBag.FalhouTamanho = true;
                ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
                return View(merViewModel);

            }

            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            return View(merViewModel);
        }
    }
}
