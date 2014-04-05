using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;

namespace LojaVirtual.Infraestrutura.Maps
{
    [Table("Foto")]
    public class FotoMap : IMap
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public int Tamanho { get; set; }
        public string Formato { get; set; }

        [Required]
        public virtual MercadoriaMap Mercadoria { get; set; }

        public void Atualizar(IContexto contexto)
        {
           
        }
        
        public void RemoverDependencias(IContexto contexto)
        {
            
        }
    }
}
