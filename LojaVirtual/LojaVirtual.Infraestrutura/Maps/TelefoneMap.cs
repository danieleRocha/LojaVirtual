using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;

namespace LojaVirtual.Infraestrutura.Maps
{
    [Table("Telefone")]
    public class TelefoneMap : IMap
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Ddd { get; set; }

        [Required]
        public string Numero { get; set; }

        public string Tipo { get; set; }

        [Required]
        public virtual UsuarioMap Usuario { get; set; }

        public void Atualizar(IContexto contexto)
        {
            
        }
        
        public void RemoverDependencias(IContexto contexto)
        {
           
        }
    }
}
