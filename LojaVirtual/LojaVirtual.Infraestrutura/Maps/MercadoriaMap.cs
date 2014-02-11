using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;

namespace LojaVirtual.Infraestrutura.Maps
{
    [Table("Mercadoria")]
    public class MercadoriaMap : IMap
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataDeCadastramento { get; set; }
        public string Cores { get; set; }

        [Required]
        public virtual ICollection<CategoriaMap> Categorias { get; set; }
        public virtual ICollection<FotoMap> Fotos { get; set; }

        [Required]
        public virtual ICollection<ProdutoMap> Produtos { get; set; }

        public MercadoriaMap()
        {
            Fotos = new Collection<FotoMap>();
            Produtos = new Collection<ProdutoMap>();
            Categorias = new Collection<CategoriaMap>();
        }

        public void Atualizar(Contexto contexto)
        {
            
        }
        
        public void RemoverDependencias(Contexto contexto)
        {
            
        }
    }
}
