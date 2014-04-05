using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LojaVirtual.Apresentacao.Paginacao;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class UsuarioViewModel 
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe seu nome.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe seu Cpf.")]
        public string Cpf { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe seu e-mail.")]
        [EmailAddress(ErrorMessage = "* E-mail inválido.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe sua senha.")]
        public string Senha { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe sua data de nascimento.")]
        public DateTime DataDeNascimento { get; set; }

        public Usuario.Sexos Sexo { get; set; }
        public Permissao Permissao { get; set; }

        private List<Endereco> enderecos = new List<Endereco>();

        public List<Endereco> Enderecos
        {
            get { return enderecos; }
            set { enderecos = value; }
        }

        private List<Telefone> telefones = new List<Telefone>();

        public List<Telefone> Telefones
        {
            get { return telefones; }
            set { telefones = value; }
        }
    }

}