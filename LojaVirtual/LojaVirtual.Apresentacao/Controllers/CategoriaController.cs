using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LojaVirtual.Apresentacao.Paginacao;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Fabrica;
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
            if (!ModelState.IsValid)
            {
                ViewData[CategoriasViewModel.MercadoriasCadastradas] = repositorioDeMercadorias.ObterTodos();
                return View();
            }

            if (form[CategoriasViewModel.MercadoriasSelecionadas] != null)
            {
                var ids = form[CategoriasViewModel.MercadoriasSelecionadas].Split(',');
                categoriaViewModel.Mercadorias.Clear();

                foreach (var id in ids)
                {
                    categoriaViewModel.Mercadorias.Add(repositorioDeMercadorias.Obter(Guid.Parse(id)));
                }
            }

            var categoria = Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
            FabricaDeCategoria.Instancia().ObterCategoria(categoria);

            bool adicionado = repositorioDeCategorias.Adicionar(categoria);

            if (adicionado)
                return RedirectToAction("Listar");

            ViewData[CategoriasViewModel.MercadoriasCadastradas] = repositorioDeMercadorias.ObterTodos();
            ViewBag.Errou = true;
            ViewBag.Mensagem = "Não foi possível cadastrar a Categoria. Por favor informe ao administrador do sistema.";
            return View();
        }

        public ActionResult Listar(int? pagina)
        {
            var categorias = Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(repositorioDeCategorias.ObterTodos());

            var paginacao = new Paginacao<CategoriaViewModel>(categorias, 5);
            paginacao.VaParaPagina(pagina);
            return View(paginacao);
        }

        public ActionResult Detalhes(Guid id)
        {
            var categoria = Mapper.Map<Categoria, CategoriaViewModel>(repositorioDeCategorias.Obter(id));
            return View(categoria);
        }

        public ActionResult Excluir(Guid id, int? pagina)
        {
            bool removido = repositorioDeCategorias.Excluir(id);
            return RedirectToAction("Listar", new { pagina = pagina });
        }

        [HttpGet]
        public ActionResult Editar(Guid id)
        {
            ViewData[CategoriasViewModel.MercadoriasCadastradas] = repositorioDeMercadorias.ObterTodos();

            var categoria = Mapper.Map<Categoria, CategoriaViewModel>(repositorioDeCategorias.Obter(id));

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Editar(CategoriaViewModel categoriaViewModel)
        {
            var categoriaModel = Mapper.Map<Categoria, CategoriaViewModel>(repositorioDeCategorias.Obter(categoriaViewModel.Id));

            if (!ModelState.IsValid)
            {
                ViewData[CategoriasViewModel.MercadoriasCadastradas] = repositorioDeMercadorias.ObterTodos();
                return View(categoriaModel);

            }

            var categoria = Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);

            bool editado = repositorioDeCategorias.Editar(categoria);

            if (editado)
                return RedirectToAction("Detalhes", new { id = categoria.Id });

            ViewData[CategoriasViewModel.MercadoriasCadastradas] = repositorioDeMercadorias.ObterTodos();
            ViewBag.Errou = true;
            ViewBag.Mensagem = "Não foi possível editar a Categoria. Por favor informe ao administrador do sistema.";
            return View(categoriaModel);
        }
    }
}
