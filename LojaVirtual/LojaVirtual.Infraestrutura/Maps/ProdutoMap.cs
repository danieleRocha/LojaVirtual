using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;

namespace LojaVirtual.Infraestrutura.Maps
{
    [Table("Produto")]
    public class ProdutoMap : IMap
    {
        [Key]
        public Guid Id { get; set; }

        public string Tamanho { get; set; }
        public string Estado { get; set; }

        [Required]
        public virtual MercadoriaMap Mercadoria { get; set; }

        public void Atualizar(Contexto contexto)
        {
            throw new NotImplementedException();
        }
        
        public void RemoverDependencias(Contexto contexto)
        {
            throw new NotImplementedException();
        }
    }
}
