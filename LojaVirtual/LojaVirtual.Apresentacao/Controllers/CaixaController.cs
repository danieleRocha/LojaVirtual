using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Modelo;
using LojaVirtual.Servico;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class CaixaController : Controller
    {
        public ActionResult FinalizarCompra()
        {
            var carrinho = Compras.MeuCarrinho.ObterCarrinho();

            if (!carrinho.Itens.Any())
            {
                return RedirectToAction("Carrinho", "Carrinho");
            }

            var usuario = Seguranca.Autenticacao.ObterUsuarioAutenticado();

            if (usuario == null)
                return RedirectToAction("Login", "Login");


            //Todo: Fazer a view de agradecimento pela compra e de visualização das compras passadas.

            return RedirectToAction("Login", "Login");
        }

    }
}
