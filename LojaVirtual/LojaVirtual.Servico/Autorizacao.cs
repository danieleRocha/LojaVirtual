using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;


namespace LojaVirtual.Servico
{
    public class Autorizacao:RoleProvider
    {
        private string applicationName;

        private IRepositorio<Usuario> repositorioDeUsuarios
        {
            get { return DependencyResolver.Current.GetService<IRepositorio<Usuario>>(); }
        }
        private IRepositorio<Permissao> repositorioDePermissoes
        {
            get { return DependencyResolver.Current.GetService<IRepositorio<Permissao>>(); }
        }

        public override bool IsUserInRole(string username, string email)
        {
            foreach (var permissao in repositorioDePermissoes.ObterTodos())
            {
                if (permissao.Tipo.ToString() == email)
                {
                    if (permissao.Usuarios.Any(u => u.Email == username))
                        return true;
                    break;
                }
            }

            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            var roles = new string[1];

            foreach (var permissao in repositorioDePermissoes.ObterTodos().Where(permissao => permissao.Usuarios.Any(usuario => usuario.Email == username)))
            {
                roles[0] = permissao.Tipo.ToString();
                return roles;
            }

            return roles;
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { return applicationName; }
            set { applicationName = value; }
        }
    }
}
