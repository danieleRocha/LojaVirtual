using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LojaVirtual.Apresentacao.Paginacao;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class LoginViewModel 
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe seu e-mail.")]
        [EmailAddress(ErrorMessage = "* E-mail inválido.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe sua senha.")]
        public string Senha { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe seu e-mail.")]
        [EmailAddress(ErrorMessage = "* E-mail inválido.")]
        public string EmailCadastro { get; set; }

        public string Cpf { get; set; }
    
    }

}