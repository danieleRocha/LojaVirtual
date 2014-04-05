using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using LojaVirtual.Infraestrutura.Autenticacao;

namespace LojaVirtual.Infraestrutura.Maps
{
    [Table("Permissao")]
    public class PermissaoMap : IMap
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual ICollection<UsuarioMap> Usuarios { get; set; }

        public void Atualizar(IContexto contexto)
        {
            
        }
        
        public void RemoverDependencias(IContexto contexto)
        {
           
        }
    }
}
