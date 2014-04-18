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
        public virtual EnderecoMap Endereco { get; set; }

        public virtual PermissaoMap Permissao { get; set; }

        public UsuarioMap()
        {
            Telefones = new Collection<TelefoneMap>();
        }

        public void Atualizar(IContexto contexto)
        {
            var usuarioParaAtualizar = ((ContextoAutenticacao)contexto).Usuario.Find(Id);
            if (usuarioParaAtualizar != null)
            {
                var telefonesParaRemover = new List<TelefoneMap>();
                IDao<TelefoneMap> telefoneDao = FabricaDeDaos.Instancia().ObterDao<TelefoneMap>(contexto);
                
                foreach (var telefone in usuarioParaAtualizar.Telefones)
                {
                    bool remover = Telefones.All(f => f.Id != telefone.Id);
                    if (remover)
                        telefonesParaRemover.Add(telefone);
                }

                foreach (var telefoneMap in telefonesParaRemover)
                {
                    telefoneDao.Excluir(telefoneMap.Id);
                }

                
                foreach (var telefone in Telefones)
                {
                    bool adicionar = usuarioParaAtualizar.Telefones.All(f => f.Id != telefone.Id);
                    if (adicionar)
                    {
                        usuarioParaAtualizar.Telefones.Add(telefone);
                    }
                }

            }
        }
        
        public void RemoverDependencias(IContexto contexto)
        {
           
        }
    }
}
