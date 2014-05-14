using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LojaVirtual.Apresentacao.Helpers;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;
using LojaVirtual.Servico;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class CarrinhoController : Controller
    {
        private IRepositorio<Categoria> repositorioDeCategorias;
        private IRepositorio<Mercadoria> repositorioDeMercadorias;

        public CarrinhoController(IRepositorio<Categoria> repositorioDeCategorias, IRepositorio<Mercadoria> repositorioDeMercadorias)
        {
            this.repositorioDeCategorias = repositorioDeCategorias;
            this.repositorioDeMercadorias = repositorioDeMercadorias;
        }

        public ActionResult Carrinho()
        {
            var carrinho = Compras.MeuCarrinho.ObterCarrinho();
            var carrinhoViewModel = Mapper.Map<Carrinho, CarrinhoViewModel>(carrinho);
            carrinhoViewModel.DecorarItens(repositorioDeMercadorias.ObterTodos());
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            return View(carrinhoViewModel);
        }

        [HttpPost]
        [Submit("ContinuarComprando")]
        public ActionResult Carrinho(CarrinhoViewModel carrinhoViewModel, FormCollection form)
        {
            var carrinho = Compras.MeuCarrinho.ObterCarrinho();

            if (form.AllKeys.Contains("ApagouTudo"))
            {
                if (form["ApagouTudo"] == "1")
                {
                    carrinho.RemoverTudo();
                }
                else
                {
                    for (int i = 0; i < carrinho.Itens.Count(); i++)
                    {
                        carrinho.Itens.ToList()[i].Quantidade = carrinhoViewModel.Itens[i].Quantidade;
                    }

                    var itensParaRemover = new List<Guid>();
                    for (int i = 0; i < carrinho.Itens.Count(); i++)
                    {
                        var itemExcluido = "iteme" + i;

                        if (form.AllKeys.Contains(itemExcluido))
                        {
                            var foiEscluido = form[itemExcluido];

                            if (foiEscluido == "1")
                            {
                                itensParaRemover.Add(carrinho.Itens.ToList()[i].Id);
                            }
                        }
                    }

                    foreach (var guid in itensParaRemover)
                    {
                        carrinho.RemoverItem(guid);
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Submit("FinalizarCompra")]
        public ActionResult Carrinho(Guid? id, CarrinhoViewModel carrinhoViewModel, FormCollection form)
        {
            var carrinho = Compras.MeuCarrinho.ObterCarrinho();

            if (form.AllKeys.Contains("ApagouTudo"))
            {
                if (form["ApagouTudo"] == "1")
                {
                    carrinho.RemoverTudo();
                }
                else
                {
                    for (int i = 0; i < carrinho.Itens.Count(); i++)
                    {
                        carrinho.Itens.ToList()[i].Quantidade = carrinhoViewModel.Itens[i].Quantidade;
                    }

                    var itensParaRemover = new List<Guid>();
                    for (int i = 0; i < carrinho.Itens.Count(); i++)
                    {
                        var itemExcluido = "iteme" + i;

                        if (form.AllKeys.Contains(itemExcluido))
                        {
                            var foiEscluido = form[itemExcluido];

                            if (foiEscluido == "1")
                            {
                                itensParaRemover.Add(carrinho.Itens.ToList()[i].Id);
                            }
                        }
                    }

                    foreach (var guid in itensParaRemover)
                    {
                        carrinho.RemoverItem(guid);
                    }
                }
            }

            return RedirectToAction("FinalizarCompra", "Caixa");
        }

        public ActionResult AdicionarProduto(Produto produto)
        {
            var carrinho = Compras.MeuCarrinho.ObterCarrinho();
            carrinho.AdicionarItem(produto, 1);
            var carrinhoViewModel = Mapper.Map<Carrinho, CarrinhoViewModel>(carrinho);
            carrinhoViewModel.DecorarItens(repositorioDeMercadorias.ObterTodos());
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            return View("Carrinho", carrinhoViewModel);
        }

        [HttpPost]
        [Submit("ContinuarComprando")]
        public ActionResult AdicionarProduto(CarrinhoViewModel carrinhoViewModel, FormCollection form)
        {
            var carrinho = Compras.MeuCarrinho.ObterCarrinho();

            if (form.AllKeys.Contains("ApagouTudo"))
            {
                if (form["ApagouTudo"] == "1")
                {
                    carrinho.RemoverTudo();
                }
                else
                {
                    for (int i = 0; i < carrinho.Itens.Count(); i++)
                    {
                        carrinho.Itens.ToList()[i].Quantidade = carrinhoViewModel.Itens[i].Quantidade;
                    }

                    var itensParaRemover = new List<Guid>();
                    for (int i = 0; i < carrinho.Itens.Count(); i++)
                    {
                        var itemExcluido = "iteme" + i;

                        if (form.AllKeys.Contains(itemExcluido))
                        {
                            var foiEscluido = form[itemExcluido];

                            if (foiEscluido == "1")
                            {
                                itensParaRemover.Add(carrinho.Itens.ToList()[i].Id);
                            }
                        }
                    }

                    foreach (var guid in itensParaRemover)
                    {
                        carrinho.RemoverItem(guid);
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Submit("FinalizarCompra")]
        public ActionResult AdicionarProduto(Guid? id, CarrinhoViewModel carrinhoViewModel, FormCollection form)
        {
            var carrinho = Compras.MeuCarrinho.ObterCarrinho();

            if (form.AllKeys.Contains("ApagouTudo"))
            {
                if (form["ApagouTudo"] == "1")
                {
                    carrinho.RemoverTudo();
                }
                else
                {
                    for (int i = 0; i < carrinho.Itens.Count(); i++)
                    {
                        carrinho.Itens.ToList()[i].Quantidade = carrinhoViewModel.Itens[i].Quantidade;
                    }

                    var itensParaRemover = new List<Guid>();
                    for (int i = 0; i < carrinho.Itens.Count(); i++)
                    {
                        var itemExcluido = "iteme" + i;

                        if (form.AllKeys.Contains(itemExcluido))
                        {
                            var foiEscluido = form[itemExcluido];

                            if (foiEscluido == "1")
                            {
                                itensParaRemover.Add(carrinho.Itens.ToList()[i].Id);
                            }
                        }
                    }

                    foreach (var guid in itensParaRemover)
                    {
                        carrinho.RemoverItem(guid);
                    }
                }
            }

           return RedirectToAction("FinalizarCompra", "Caixa");

        }

    }
}
