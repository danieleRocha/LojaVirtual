using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using LojaVirtual.Infraestrutura.Autenticacao;

namespace LojaVirtual.Infraestrutura.Maps
{
    [Table("Usuario")]
    public class UsuarioMap : IMap
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public DateTime DataDeNascimento { get; set; }

        public string Sexo { get; set; }

        [Required]
        public virtual ICollection<TelefoneMap> Telefones { get; set; }

        [Required]
        public EnderecoMap Endereco { get; set; }

        [Required]
        public virtual PermissaoMap Permissao { get; set; }

        public UsuarioMap()
        {
            Telefones = new Collection<TelefoneMap>();
        }

        public void Atualizar(IContexto contexto)
        {
            
        }
        
        public void RemoverDependencias(IContexto contexto)
        {
           
        }
    }
}
