using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;
using LojaVirtual.Infraestrutura.Autenticacao;

namespace LojaVirtual.Infraestrutura.Maps
{
    [Table("Permissao")]
    public class PermissaoMap : IMap
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public virtual ICollection<UsuarioMap> Usuarios { get; set; }

        public PermissaoMap()
        {
            Usuarios = new Collection<UsuarioMap>();
        }

        public void Atualizar(IContexto contexto)
        {
            var permissaoParaAtualizar = ((ContextoAutenticacao)contexto).Permissao.Find(Id);
            if (permissaoParaAtualizar != null)
            {
                var usuariosParaRemover = new List<UsuarioMap>();

                foreach (var usuario in permissaoParaAtualizar.Usuarios)
                {
                    bool remover = Usuarios.All(a => a.Id != usuario.Id);
                    if (remover)
                        usuariosParaRemover.Add(usuario);
                }

                foreach (var usuarioMap in usuariosParaRemover)
                {
                    permissaoParaAtualizar.Usuarios.Remove(usuarioMap);
                }

                foreach (var usuario in Usuarios)
                {
                    bool adicionar = permissaoParaAtualizar.Usuarios.All(a => a.Id != usuario.Id);
                    if (adicionar)
                    {
                        var us = ((ContextoAutenticacao)contexto).Usuario.Find(usuario.Id);
                        if (us != null)
                        {
                            permissaoParaAtualizar.Usuarios.Add(us);
                        }
                        else
                        {
                            permissaoParaAtualizar.Usuarios.Add(usuario);
                        }

                    }
                }
            }
        }
        
        public void RemoverDependencias(IContexto contexto)
        {
           
        }
    }
}
