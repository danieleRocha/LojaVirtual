using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LojaVirtual.Apresentacao.Model;
using LojaVirtual.Apresentacao.Paginacao;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Fabrica;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;
using LojaVirtual.Servico;

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
        [FiltroSeguranca(Roles = "Gerente,Administrador")]
        public ActionResult Adicionar()
        {
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            MercadoriaViewModel mercadoriaViewModel = new MercadoriaViewModel();
            return View(mercadoriaViewModel);
        }

        [HttpPost]
        [FiltroSeguranca(Roles = "Gerente,Administrador")]
        public ActionResult Adicionar(MercadoriaViewModel mercadoriaViewModel, FormCollection form,
                                      HttpPostedFileBase file)
        {
            if (form[MercadoriasViewModel.CategoriasSelecionadas] != null)
            {
                var ids = form[MercadoriasViewModel.CategoriasSelecionadas].Split(',');
                mercadoriaViewModel.Categorias = new List<Categoria>();

                foreach (var id in ids)
                {
                    mercadoriaViewModel.Categorias.Add(repositorioDeCategorias.Obter(Guid.Parse(id)));
                }
            }

            if (mercadoriaViewModel.QuantidadeDeTamanhos != null)
            {
                mercadoriaViewModel.Tamanhos = new List<KeyValuePair<string, string>>((int)mercadoriaViewModel.QuantidadeDeTamanhos);
                for (int i = 0; i < mercadoriaViewModel.QuantidadeDeTamanhos; i++)
                {
                    if ((form["tamanho" + (i + 1)] != null) && (form["quantidadeTamanho" + (i + 1)] != null))
                    {
                        mercadoriaViewModel.Tamanhos.Add(new KeyValuePair<string, string>(form["tamanho" + (i + 1)],
                                                                                          form["quantidadeTamanho" + (i + 1)
                                                                                              ]));
                    }
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

            mercadoriaViewModel.Imagens.AddRange(FabricaDeImagem.Instancia().CriarImagens(mercadoriaViewModel.Arquivos));

            for (int i = 0; i < MercadoriasViewModel.NumeroDeFotosPermitidas; i++)
            {
                var imagem = "imagem" + i;
                var nomeImagem = imagem + "Nome";
                var conteudoImagem = imagem + "Conteudo";
                var tamanhoImagem = imagem + "Tamanho";
                var formatoImagem = imagem + "Formato";

                if ((form[imagem] != null) && (form[imagem] != string.Empty))
                {
                    mercadoriaViewModel.Imagens.Add(FabricaDeImagem.Instancia().CriarImagem(form[nomeImagem],
                                                                                            form[formatoImagem],
                                                                                            form[conteudoImagem],
                                                                                            form[tamanhoImagem]));
                }
            }

            if ((mercadoriaViewModel.Categorias == null) || (mercadoriaViewModel.Categorias.Count == 0))
                ModelState.AddModelError("Cat", "* É necessário selecionar pelo menos uma Categoria.");

            if ((mercadoriaViewModel.Cores == null) || (mercadoriaViewModel.Cores.Count == 0))
                ModelState.AddModelError("Cor", "* É necessário selecionar pelo menos uma Cor.");

            foreach (var tamanho in mercadoriaViewModel.Tamanhos)
            {
                int quantidade;

                try
                {
                    quantidade = Convert.ToInt32(tamanho.Value);
                }
                catch
                {
                    ModelState.AddModelError("Tamanho",
                                             "* A quantidade especificada para o tamanho " + tamanho.Key +
                                             " é inválida.");
                    continue;
                }

                if (quantidade < 0)
                    ModelState.AddModelError("Tamanho", "* A quantidade especificada para o tamanho " + tamanho.Key + " deve ser maior que zero.");

            }

            if (mercadoriaViewModel.Imagens.Count == 0)
                ModelState.AddModelError("Foto", "* É necessário carregar pelo menos uma Foto.");

            if (!ModelState.IsValid)
            {
                ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
                return View(mercadoriaViewModel);
            }

            var mercadoria = Mapper.Map<MercadoriaViewModel, Mercadoria>(mercadoriaViewModel);

            FabricaDeMercadoria.Instancia()
                               .CriarMercadoria(mercadoria, mercadoriaViewModel.Tamanhos, mercadoriaViewModel.Arquivos);

            bool adicionado = false;

            for (int i = 0; i < mercadoriaViewModel.Categorias.Count; i++)
            {
                var categoria = repositorioDeCategorias.Obter(mercadoriaViewModel.Categorias[i].Id);
                categoria.AdicionarMercadoria(mercadoria);
                if (repositorioDeCategorias.Editar(categoria))
                    adicionado = true;
                else
                {
                    adicionado = false;
                    break;
                }
            }

            if (adicionado)
                return RedirectToAction("Listar");

            ViewBag.Errou = true;
            ViewBag.Mensagem = "Não foi possível cadastrar a Mercadoria. Por favor informe ao administrador do sistema.";
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            return View(mercadoriaViewModel);
        }

        [FiltroSeguranca(Roles = "Gerente,Administrador")]
        public ActionResult Listar(int? pagina)
        {
            var mercadorias = Mapper.Map<IEnumerable<Mercadoria>, IEnumerable<MercadoriaViewModel>>(repositorioDeMercadorias.ObterTodos());

            var paginacao = new Paginacao<MercadoriaViewModel>(mercadorias, 5);
            paginacao.VaParaPagina(pagina);
            return View(paginacao);
        }

        [FiltroSeguranca(Roles = "Gerente,Administrador")]
        public ActionResult Excluir(Guid id, int pagina)
        {
            bool removido = repositorioDeMercadorias.Excluir(id);
            return RedirectToAction("Listar", new { pagina = pagina });
        }

        [FiltroSeguranca(Roles = "Gerente,Administrador")]
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

        [HttpGet]
        [FiltroSeguranca(Roles = "Gerente,Administrador")]
        public ActionResult Editar(Guid id)
        {
            ViewData[MercadoriasViewModel.Mercadorias]= new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            var mercadoria = Mapper.Map<Mercadoria, MercadoriaViewModel>(repositorioDeMercadorias.Obter(id));
            mercadoria.QuantidadeDeTamanhos = mercadoria.Tamanhos.Count;
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

        [HttpPost]
        [FiltroSeguranca(Roles = "Gerente,Administrador")]
        public ActionResult Editar(MercadoriaViewModel mercadoriaViewModel, FormCollection form)
        {
            if (form[MercadoriasViewModel.CategoriasSelecionadas] != null)
            {
                var ids = form[MercadoriasViewModel.CategoriasSelecionadas].Split(',');
                mercadoriaViewModel.Categorias = new List<Categoria>();

                foreach (var id in ids)
                {
                    mercadoriaViewModel.Categorias.Add(repositorioDeCategorias.Obter(Guid.Parse(id)));
                }
            }

            if (mercadoriaViewModel.QuantidadeDeTamanhos != null)
            {
                mercadoriaViewModel.Tamanhos = new List<KeyValuePair<string, string>>((int)mercadoriaViewModel.QuantidadeDeTamanhos);
                for (int i = 0; i < mercadoriaViewModel.QuantidadeDeTamanhos; i++)
                {
                    if ((form["tamanho" + (i + 1)] != null) && (form["quantidadeTamanho" + (i + 1)] != null))
                    {
                        mercadoriaViewModel.Tamanhos.Add(new KeyValuePair<string, string>(form["tamanho" + (i + 1)],
                                                                                          form["quantidadeTamanho" + (i + 1)
                                                                                              ]));
                    }
                }
            }

            var mercadoriaViewModelAntiga = Mapper.Map<Mercadoria, MercadoriaViewModel>(repositorioDeMercadorias.Obter(mercadoriaViewModel.Id));

            foreach (var categoria in repositorioDeCategorias.ObterTodos())
            {
                foreach (var merc in categoria.Mercadorias.Where(merc => merc.Id == mercadoriaViewModelAntiga.Id))
                {
                    mercadoriaViewModelAntiga.Categorias.Add(categoria);
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

            mercadoriaViewModel.Imagens.AddRange(FabricaDeImagem.Instancia().CriarImagens(mercadoriaViewModel.Arquivos));

            for (int i = 0; i < MercadoriasViewModel.NumeroDeFotosPermitidas; i++)
            {
                var imagem = "imagem" + i;
                var nomeImagem = imagem + "Nome";
                var conteudoImagem = imagem + "Conteudo";
                var tamanhoImagem = imagem + "Tamanho";
                var formatoImagem = imagem + "Formato";

                if ((form[imagem] != null) && (form[imagem] != string.Empty))
                {
                    mercadoriaViewModel.Imagens.Add(FabricaDeImagem.Instancia().CriarImagem(form[nomeImagem],
                                                                                            form[formatoImagem],
                                                                                            form[conteudoImagem],
                                                                                            form[tamanhoImagem]));
                }
            }

            if ((mercadoriaViewModel.Categorias == null) || (mercadoriaViewModel.Categorias.Count == 0))
                ModelState.AddModelError("Cat", "* É necessário selecionar pelo menos uma Categoria.");

            if ((mercadoriaViewModel.Cores == null) || (mercadoriaViewModel.Cores.Count == 0))
                ModelState.AddModelError("Cor", "* É necessário selecionar pelo menos uma Cor.");

            foreach (var tamanho in mercadoriaViewModel.Tamanhos)
            {
                int quantidade;

                try
                {
                    quantidade = Convert.ToInt32(tamanho.Value);
                }
                catch
                {
                    ModelState.AddModelError("Tamanho",
                                             "* A quantidade especificada para o tamanho " + tamanho.Key +
                                             " é inválida.");
                    continue;
                }

                if (quantidade < 0)
                    ModelState.AddModelError("Tamanho", "* A quantidade especificada para o tamanho " + tamanho.Key + " deve ser maior que zero.");

            }

            if (mercadoriaViewModel.Imagens.Count == 0)
                ModelState.AddModelError("Foto", "* É necessário carregar pelo menos uma Foto.");

            if (!ModelState.IsValid)
            {
                ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
                return View(mercadoriaViewModel);
            }


            var mercadoria = Mapper.Map<MercadoriaViewModel, Mercadoria>(mercadoriaViewModel);

            var mercadoriaAntiga = repositorioDeMercadorias.Obter(mercadoriaViewModel.Id);

            mercadoria.DataDeCadastramento = mercadoriaAntiga.DataDeCadastramento;
            
            FabricaDeMercadoria.Instancia()
                               .EditarMercadoria(mercadoria, mercadoriaViewModel.Tamanhos, mercadoriaViewModel.Arquivos);

            bool editada = repositorioDeMercadorias.Editar(mercadoria);

            for (int i = 0; i < mercadoriaViewModelAntiga.Categorias.Count; i++)
            {
                var categoria = repositorioDeCategorias.Obter(mercadoriaViewModelAntiga.Categorias[i].Id);

                bool remover = mercadoriaViewModel.Categorias.All(cat => cat.Id != categoria.Id);
                if (remover)
                    categoria.RemoverMercadoria(mercadoriaViewModel.Id);

                if (repositorioDeCategorias.Editar(categoria))
                    editada = true;
                else
                {
                    editada = false;
                    goto final;
                }
            }

            for (int i = 0; i < mercadoriaViewModel.Categorias.Count; i++)
            {
                var categoria = repositorioDeCategorias.Obter(mercadoriaViewModel.Categorias[i].Id);
                categoria.AdicionarMercadoria(mercadoria);
                if (repositorioDeCategorias.Editar(categoria))
                    editada = true;
                else
                {
                    editada = false;
                    break;
                }
            }

        final:
            if (editada)
                return RedirectToAction("Detalhes", new { id = mercadoria.Id } );

            ViewBag.Errou = true;
            ViewBag.Mensagem = "Não foi possível editar a Mercadoria. Por favor informe ao administrador do sistema.";
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            return View(mercadoriaViewModel);
        }
    }
}
