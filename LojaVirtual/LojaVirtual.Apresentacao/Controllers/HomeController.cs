using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LojaVirtual.Apresentacao.Model;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Fabrica;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;
using LojaVirtual.Servico;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        private IRepositorio<Categoria> repositorioDeCategorias;

        public HomeController(IRepositorio<Categoria> repositorioDeCategorias)
        {
            this.repositorioDeCategorias = repositorioDeCategorias;
        }

        public ActionResult Index()
        {
            Usuario usuario = Seguranca.Autenticacao.ObterUsuarioAutenticado();
            UsuarioViewModel usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());

            bool temPermissaoTotal = false;

            if (usuario != null)
            {
                temPermissaoTotal = Seguranca.Autorizacao.IsUserInRole(usuario.Email, "Gerente");
                if (!temPermissaoTotal)
                    temPermissaoTotal = Seguranca.Autorizacao.IsUserInRole(usuario.Email, "Administrador");
            }

            ViewBag.EAdministradorOuGerente = temPermissaoTotal;
            return View(usuarioViewModel);
        }

        public ActionResult NaoAutorizado()
        {
            return View("NaoAutorizado");
        }

        [FiltroSeguranca(Roles = "Gerente,Administrador")]
        public ActionResult BarraMenu()
        {
            return View();
        }

        
    }
}
