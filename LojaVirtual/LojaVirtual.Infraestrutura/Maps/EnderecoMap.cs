using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;

namespace LojaVirtual.Infraestrutura.Maps
{
    [Table("Endereco")]
    public class EnderecoMap : IMap
    {
        [Key]
        public Guid Id { get; set; }
        public string TipoDeLogradouro { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Apelido { get; set; }

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
