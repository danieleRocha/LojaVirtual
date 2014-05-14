using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace LojaVirtual.Infraestrutura.Maps
{
    [Table("Compra")]
    public class CompraMap : IMap
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public virtual UsuarioMap Usuario { get; set; }
        
        [Required]
        public virtual ICollection<ProdutoMap> Produtos { get; set; }

        public CompraMap()
        {
            Produtos = new Collection<ProdutoMap>();
        }

        public void Atualizar(IContexto contexto)
        {
            
        }

        public void RemoverDependencias(IContexto contexto)
        {
            
        }
    }
}
