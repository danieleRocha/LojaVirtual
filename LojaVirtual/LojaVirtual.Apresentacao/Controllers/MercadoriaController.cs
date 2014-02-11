using System;
using System.Collections.Generic;
using System.Drawing;
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
    public class MercadoriaController : Controller
    {
        private IRepositorio<Categoria> repositorioDeCategorias;
        private IRepositorio<Mercadoria> repositorioDeMercadorias;

        public MercadoriaController(IRepositorio<Mercadoria> repositorioDeMercadorias, IRepositorio<Categoria> repositorioDeCategorias)
        {
            this.repositorioDeCategorias = repositorioDeCategorias;
            this.repositorioDeMercadorias = repositorioDeMercadorias;
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            var mercadoriasViewModel = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            ViewData[MercadoriasViewModel.Mercadorias] = mercadoriasViewModel;
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(MercadoriaViewModel mercadoriaViewModel, FormCollection form,
                                      HttpPostedFileBase file)
        {
            if (form[MercadoriasViewModel.MercadoriasSelecionadas] != null)
            {
                var ids = form[MercadoriasViewModel.MercadoriasSelecionadas].Split(',');
                mercadoriaViewModel.Categorias = new List<Categoria>();

                foreach (var id in ids)
                {
                    mercadoriaViewModel.Categorias.Add(repositorioDeCategorias.Obter(Guid.Parse(id)));
                }
            }

            mercadoriaViewModel.Tamanhos = new List<KeyValuePair<string, string>>(mercadoriaViewModel.NumeroDeTamanhos);
            for (int i = 0; i < mercadoriaViewModel.NumeroDeTamanhos; i++)
            {
                if ((form["tamanho" + (i + 1)] != null) && (form["quantidadeTamanho" + (i + 1)] != null))
                {
                    mercadoriaViewModel.Tamanhos.Add(new KeyValuePair<string, string>(form["tamanho" + (i + 1)],
                                                                                      form["quantidadeTamanho" + (i + 1)
                                                                                          ]));
                }
            }

            mercadoriaViewModel.Arquivos = new List<HttpPostedFileWrapper>();
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var imagem = Request.Files[i] as HttpPostedFileWrapper;
                if ((imagem != null) && (imagem.ContentLength > 0))
                {
                    mercadoriaViewModel.Arquivos.Add(imagem);
                }
            }

            var mercadoria = Mapper.Map<MercadoriaViewModel, Mercadoria>(mercadoriaViewModel);

            FabricaDeMercadoria.Instancia()
                               .ObterMercadoria(mercadoria, mercadoriaViewModel.Tamanhos, mercadoriaViewModel.Arquivos);

            bool adicionado = false;

            for (int i = 0; i < mercadoriaViewModel.Categorias.Count; i++)
            {
                var categoria = repositorioDeCategorias.Obter(mercadoriaViewModel.Categorias[i].Id);
                categoria.AdicionarMercadoria(mercadoria);
                if (repositorioDeCategorias.Editar(categoria))
                    adicionado = true;
            }

            if (adicionado)
                return RedirectToAction("Listar");

            return RedirectToAction("Adicionar");
        }

        public ActionResult Listar(int? pagina)
        {
            var mercadorias = Mapper.Map<IEnumerable<Mercadoria>, IEnumerable<MercadoriaViewModel>>(repositorioDeMercadorias.ObterTodos());

            var paginacao = new Paginacao<MercadoriaViewModel>(mercadorias, 5);
            paginacao.VaParaPagina(pagina);
            return View(paginacao);
        }

        public ActionResult Excluir(Guid id, int pagina)
        {
            bool removido = repositorioDeMercadorias.Excluir(id);
            return RedirectToAction("Listar", new { pagina = pagina });
        }

        public ActionResult Detalhes(Guid id)
        {
            var mercadoria = Mapper.Map<Mercadoria, MercadoriaViewModel>(repositorioDeMercadorias.Obter(id));
            mercadoria.Categorias.Clear();
            foreach (var categoria in repositorioDeCategorias.ObterTodos())
            {
                foreach (var merc in categoria.Mercadorias.Where(merc => merc.Id == mercadoria.Id))
                {
                    mercadoria.Categorias.Add(categoria);
                }
            }

            return View(mercadoria);
        }
    }
}
