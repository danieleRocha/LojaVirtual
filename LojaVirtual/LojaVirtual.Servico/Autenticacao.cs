using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;

namespace LojaVirtual.Servico
{
    public class Autenticacao
    {
        private IRepositorio<Usuario> repositorioDeUsuarios
        {
            get { return DependencyResolver.Current.GetService<IRepositorio<Usuario>>(); }
        }
        
        public bool AutenticarUsuario(string email, string senha)
        {
            foreach (var usuario in repositorioDeUsuarios.ObterTodos())
            {
                if ((usuario.Email == email) && (usuario.Senha == senha))
                {
                    FormsAuthentication.SetAuthCookie(usuario.Email,false);
                    return true;
                }
            }

            return false;
        }

        public void InvalidarUsuario()
        {
            FormsAuthentication.SignOut();
        }

        public Usuario ObterUsuarioAutenticado()
        {
            string email = HttpContext.Current.User.Identity.Name;

            if (string.IsNullOrEmpty(email))
                return null;

            return repositorioDeUsuarios.ObterTodos().FirstOrDefault(usuario => usuario.Email == email);
        }

        public bool EmailJaFoiCadastrado(string email)
        {
            if (repositorioDeUsuarios.ObterTodos().Any(us => us.Email == email))
                return true;

            return false;
        }

        public bool CpfJaFoiCadastrado(string cpf)
        {
            if (repositorioDeUsuarios.ObterTodos().Any(us => us.Cpf == cpf))
                return true;

            return false;
        }

        public string ObterEmailAPartirDoCpf(string cpf)
        {
            foreach (var usuario in repositorioDeUsuarios.ObterTodos())
            {
                if (usuario.Cpf == cpf)
                    return usuario.Email;
            }

            return null;
        }

        public bool EnviarSenhaPorEmail(string email)
        {
            foreach (var usuario in repositorioDeUsuarios.ObterTodos())
            {
                if (usuario.Email == email)
                    return EnviarEmails.Enviar(usuario);
            }

            return false;
        }

        public bool SenhaConfere(string senha)
        {
            var usuario = ObterUsuarioAutenticado();

            if (usuario == null) return false;

            return usuario.Senha == senha;
        }
    }
}
