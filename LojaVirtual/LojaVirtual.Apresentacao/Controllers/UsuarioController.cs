using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LojaVirtual.Apresentacao.Helpers;
using LojaVirtual.Apresentacao.Model;
using LojaVirtual.Apresentacao.ViewModels;
using LojaVirtual.Fabrica;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;
using LojaVirtual.Servico;

namespace LojaVirtual.Apresentacao.Controllers
{
    public class UsuarioController : Controller
    {
        private IRepositorio<Usuario> repositorioDeUsuarios;
        private IRepositorio<Permissao> repositorioDePermissoes;
        private IRepositorio<Categoria> repositorioDeCategorias;

        public UsuarioController(IRepositorio<Usuario> repositorioDeUsuarios, IRepositorio<Permissao> repositorioDePermissoes,
            IRepositorio<Categoria> repositorioDeCategorias)
        {
            this.repositorioDeUsuarios = repositorioDeUsuarios;
            this.repositorioDePermissoes = repositorioDePermissoes;
            this.repositorioDeCategorias = repositorioDeCategorias;
        }

        [HttpGet]
        public ActionResult Cadastrar(string email)
        {
            var usuarioViewModel = FabricaDeUsuarioViewModel.Instancia().CriarUsuarioViewModel(email);
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            return View(usuarioViewModel);
        }

        [HttpPost]
        public ActionResult Cadastrar(UsuarioViewModel usuarioViewModel)
        {
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            string mensagem = "Não foi possível realizar o cadastro. Por favor tente mais tarde.";

            if (Seguranca.Autenticacao.EmailJaFoiCadastrado(usuarioViewModel.Email))
            {
                mensagem = "Este e-mail já foi cadastrado. Por favor informe um novo e-mail.";
                goto errou;
            }
            if (Seguranca.Autenticacao.CpfJaFoiCadastrado(usuarioViewModel.Cpf))
            {
                mensagem = "Este CPF já foi cadastrado. Por favor informe um novo CPF.";
                goto errou;
            }

            if (!ModelState.IsValid)
            {
                ModelState nascimento = null;
                if (ModelState.TryGetValue("DataDeNascimento", out nascimento))
                {
                    if ((nascimento != null) && (nascimento.Errors.Count > 0) &&
                        (nascimento.Errors[0].ErrorMessage.Contains("DataDeNascimento")))
                    {
                        ModelState.Remove("DataDeNascimento");
                        ModelState.AddModelError("DataDeNascimento", "* Data de nascimento inválida.");
                    }
                }
            }
            ModelState cpf = null;
            if (ModelState.TryGetValue("Cpf", out cpf))
            {
                if ((cpf != null) && (cpf.Value.AttemptedValue != string.Empty))
                {
                    int numeroDeDigitos = cpf.Value.AttemptedValue.Count(char.IsNumber);

                    if (numeroDeDigitos != 11)
                    {
                        ModelState.Remove("Cpf");
                        ModelState.AddModelError("Cpf", "* Cpf inválido.");
                    }
                }
            }
            ModelState celular = null;
            if (ModelState.TryGetValue("TelefoneCelular", out celular))
            {
                if ((celular != null) && (cpf.Value.AttemptedValue != string.Empty))
                {
                    int numeroDeDigitos = celular.Value.AttemptedValue.Count(char.IsNumber);

                    if (numeroDeDigitos < 10)
                    {
                        ModelState.Remove("TelefoneCelular");
                        ModelState.AddModelError("TelefoneCelular", "* Telefone Celular inválido.");
                    }
                }
            }

            ModelState cep = null;
            if (ModelState.TryGetValue("CEP", out cep))
            {
                if ((cep != null) && (cep.Value.AttemptedValue != string.Empty))
                {
                    int numeroDeDigitos = cep.Value.AttemptedValue.Count(char.IsNumber);

                    if (numeroDeDigitos < 8)
                    {
                        ModelState.Remove("CEP");
                        ModelState.AddModelError("CEP", "* CEP inválido.");
                    }
                }
            }

            if (!ModelState.IsValid)
                return View(usuarioViewModel);

            if (usuarioViewModel.Senha != usuarioViewModel.ConfirmacaoDaSenha)
            {
                ModelState.AddModelError("ConfirmaSenha", "* Os campos Senha e Confirmação da Senha devem ser iguais.");
                return View("Cadastrar", usuarioViewModel);
            }

            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);

            FabricaDeUsuario.Instancia().CriarUsuario(usuario);

            bool adicionado = false;

            foreach (var permissao in repositorioDePermissoes.ObterTodos())
            {
                if (permissao.Tipo == Permissao.Tipos.Cliente)
                {
                    permissao.AdicionarUsuario(usuario);
                    adicionado = repositorioDePermissoes.Editar(permissao);
                }
            }

            if (adicionado)
            {
                Seguranca.Autenticacao.AutenticarUsuario(usuario.Email, usuario.Senha);
                return RedirectToAction("Index", "Home");
            }

        errou:
            ViewBag.Errou = true;
            ViewBag.Mensagem = mensagem;
            return View("Cadastrar", usuarioViewModel);
        }

        [HttpGet]
        public ActionResult Editar()
        {
            var usuario = Seguranca.Autenticacao.ObterUsuarioAutenticado();
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            return View(usuarioViewModel);
        }

        [HttpPost, ActionName("Editar")]
        [Submit("Salvar")]
        public ActionResult Editar(UsuarioViewModel usuarioViewModel)
        {
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            ModelState.Remove("Senha");
            ModelState.Remove("ConfirmacaoDaSenha");

            if (!ModelState.IsValid)
            {
                ModelState nascimento = null;
                if (ModelState.TryGetValue("DataDeNascimento", out nascimento))
                {
                    if ((nascimento != null) && (nascimento.Errors.Count > 0) &&
                        (nascimento.Errors[0].ErrorMessage.Contains("DataDeNascimento")))
                    {
                        ModelState.Remove("DataDeNascimento");
                        ModelState.AddModelError("DataDeNascimento", "* Data de nascimento inválida.");
                    }
                }
            }
            ModelState cpf = null;
            if (ModelState.TryGetValue("Cpf", out cpf))
            {
                if ((cpf != null)&&(cpf.Value.AttemptedValue!=string.Empty))
                {
                    int numeroDeDigitos = cpf.Value.AttemptedValue.Count(char.IsNumber);

                    if (numeroDeDigitos != 11)
                    {
                        ModelState.Remove("Cpf");
                        ModelState.AddModelError("Cpf", "* Cpf inválido.");
                    }
                }
            }
            ModelState celular = null;
            if (ModelState.TryGetValue("TelefoneCelular", out celular))
            {
                if ((celular != null)&&(cpf.Value.AttemptedValue!=string.Empty))
                {
                    int numeroDeDigitos = celular.Value.AttemptedValue.Count(char.IsNumber);

                    if (numeroDeDigitos < 10)
                    {
                        ModelState.Remove("TelefoneCelular");
                        ModelState.AddModelError("TelefoneCelular", "* Telefone Celular inválido.");
                    }
                }
            }

            ModelState cep = null;
            if (ModelState.TryGetValue("CEP", out cep))
            {
                if ((cep != null)&&(cep.Value.AttemptedValue!=string.Empty))
                {
                    int numeroDeDigitos = cep.Value.AttemptedValue.Count(char.IsNumber);

                    if (numeroDeDigitos < 8)
                    {
                        ModelState.Remove("CEP");
                        ModelState.AddModelError("CEP", "* CEP inválido.");
                    }
                }
            }

            if (!ModelState.IsValid)
                return View(usuarioViewModel);
            
            var usuarioAntigo = Seguranca.Autenticacao.ObterUsuarioAutenticado();

            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);

            FabricaDeUsuario.Instancia().CriarUsuario(usuario);

            //usuarioAntigo.EditarTelefones(usuario.Telefones);
            //usuarioAntigo.EditarEndereco(usuario.Endereco);
            
            usuario.Senha = usuarioAntigo.Senha;
            usuario.Id = usuarioAntigo.Id;
            //usuario.Telefones = usuarioAntigo.Telefones;
            //usuario.Endereco = usuarioAntigo.Endereco;
            
            bool editado = repositorioDeUsuarios.Editar(usuario);

            if (editado)
            {
                ViewBag.EditouDados = true;
                return View(usuarioViewModel);
            }

            ViewBag.Errou = true;
            ViewBag.Mensagem = "Não foi possível editar os dados. Por favor tente mais tarde.";
            return View(usuarioViewModel);
        }

        [HttpPost, ActionName("Editar")]
        [Submit("TrocarSenha")]
        public ActionResult TrocarSenha(UsuarioViewModel usuarioViewModel, FormCollection form)
        {
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            ModelState.Clear();

            string msgErro = string.Empty;
            string msgFalha = string.Empty;

            bool senhaAntigaConfere = false;

            if (form.AllKeys.Contains("SenhaAntiga"))
                senhaAntigaConfere = Seguranca.Autenticacao.SenhaConfere(form["SenhaAntiga"]);

            if (!senhaAntigaConfere)
            {
                msgFalha =
                    "A senha antiga não confere. Por favor tente novamente ou solicite o reenvio da senha.";
                goto falha;
            }

            bool novaSenhaEConfirmacaoSaoIguais = false;

            if ((form.AllKeys.Contains("NovaSenha")) && (form.AllKeys.Contains("ConfirmacaoNovaSenha")))
                novaSenhaEConfirmacaoSaoIguais = form["NovaSenha"] == form["ConfirmacaoNovaSenha"];

            if (!novaSenhaEConfirmacaoSaoIguais)
            {
                msgFalha =
                    "Os campos \"Nova senha\" e \"Confirme a nova senha\" devem ser iguais. Por favor tente novamente.";
                goto falha;
            }

            var usuario = Seguranca.Autenticacao.ObterUsuarioAutenticado();

            usuario.Senha = form["NovaSenha"];

            bool trocou = repositorioDeUsuarios.Editar(usuario);

            if (trocou)
            {
                ViewBag.TrocouSenha = true;
                Seguranca.Autenticacao.InvalidarUsuario();
                Seguranca.Autenticacao.AutenticarUsuario(usuarioViewModel.Email, usuario.Senha);
                ViewBag.TrocouSenha = true;
                return View(usuarioViewModel);
            }

            msgErro = "Não foi possível trocar a senha. Por favor tente mais tarde.";
            goto erro;

        falha:
            ViewBag.Errou = false;
            ViewBag.Falhou = true;
            ViewBag.Mensagem = msgErro;
            ViewBag.MensagemNaoTrocouSenha = msgFalha;
            return View(usuarioViewModel);

        erro:
            ViewBag.Errou = true;
            ViewBag.Falhou = false;
            ViewBag.Mensagem = msgErro;
            return View(usuarioViewModel);

        }

        [HttpGet]
        public ActionResult MinhasCompras()
        {
            ViewData[MercadoriasViewModel.Mercadorias] = new MercadoriasViewModel(repositorioDeCategorias.ObterTodos());
            var usuario = Seguranca.Autenticacao.ObterUsuarioAutenticado();
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);
            return View(usuarioViewModel);
        }
    }
}
