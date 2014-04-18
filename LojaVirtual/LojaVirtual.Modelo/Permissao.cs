using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace LojaVirtual.Modelo
{
    public class Permissao:ITipo
    {
        public Guid Id { get; set; }
        public Tipos Tipo { get; set; }
        private List<Usuario> usuarios = new List<Usuario>();
        public static readonly string Gerente = Tipos.Gerente.ToString();
        public static readonly string Administrador = Tipos.Administrador.ToString();
        public static readonly string Cliente = Tipos.Cliente.ToString();

        public IEnumerable<Usuario> Usuarios
        {
            get { return usuarios; }
            set { usuarios = value.ToList(); }
        }
        
        public enum Tipos
        {
            Administrador,
            Gerente,
            Cliente
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            if (usuarios.FirstOrDefault(p => p.Id == usuario.Id) == null)
                usuarios.Add(usuario);
        }

        public void RemoverUsuario(Usuario usuario)
        {
            if (usuarios.FirstOrDefault(p => p.Id == usuario.Id) == null)
                usuarios.Remove(usuario);
        }
    }
}
