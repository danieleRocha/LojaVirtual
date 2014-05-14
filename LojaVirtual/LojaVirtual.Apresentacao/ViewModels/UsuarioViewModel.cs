using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaVirtual.Apresentacao.Paginacao;
using LojaVirtual.Modelo;

namespace LojaVirtual.Apresentacao.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe seu Nome.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe seu CPF.")]
        public string Cpf { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe seu E-mail.")]
        [EmailAddress(ErrorMessage = "* E-mail inválido.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe sua Senha.")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor confirme sua Senha.")]
        public string ConfirmacaoDaSenha { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe sua Data de Nascimento.")]
        public DateTime? DataDeNascimento { get; set; }

        public Usuario.Sexos Sexo { get; set; }
        
        private Endereco endereco=new Endereco();

        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe seu Endereço.")]
        public string Logradouro
        {
            get { return endereco.Logradouro; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe o Número.")]
        public string Numero
        {
            get { return endereco.Numero; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe o CEP.")]
        public string CEP
        {
            get { return endereco.Cep; }
            set { endereco.Cep = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe a Cidade.")]
        public string Cidade
        {
            get { return endereco.Cidade; }
        }
        
        private List<Telefone> telefones = new List<Telefone>();

        public List<Telefone> Telefones
        {
            get
            {
                if (telefones.Count == 0)
                {
                    telefones.Add(ObterTelefone(Telefone.TipoDeTelefone.Residencial,TelefoneResidencial));
                    telefones.Add(ObterTelefone(Telefone.TipoDeTelefone.Celular,TelefoneCelular));
                }
                return telefones;
            }
            set
            {
                foreach (var telefone in value)
                {
                    if (telefone.Tipo == Telefone.TipoDeTelefone.Celular)
                        TelefoneCelular = ObterTelefone(telefone);
                    if (telefone.Tipo == Telefone.TipoDeTelefone.Residencial)
                        TelefoneResidencial = ObterTelefone(telefone);
                }
            }
        }

        public Carrinho Carrinho { get; set; }
        
        public string Tratamento
        {
            get
            {
                if (Sexo == Usuario.Sexos.Femenino)
                    return "Seja bem vinda, ";
                
                    return "Seja bem vindo, ";
            }
        }

        public static IEnumerable<Usuario.Sexos> Sexos = Enum.GetValues(typeof(Usuario.Sexos)).Cast<Usuario.Sexos>();

        public static IEnumerable<Endereco.Estados> EstadosDisponiveis = Enum.GetValues(typeof(Endereco.Estados)).Cast<Endereco.Estados>();

        [DataType(DataType.PhoneNumber)]
        public string TelefoneResidencial { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* Por favor informe seu Celular.")]
        public string TelefoneCelular { get; set; }

        private string ObterTelefone(Telefone telefone)
        {
            if ((telefone.Ddd == null) && (telefone.Numero == null))
                return null;

            return "(" + telefone.Ddd + ")" + telefone.Numero;
        }

        private Telefone ObterTelefone(Telefone.TipoDeTelefone tipo, string telefone)
        {
            var tel = new Telefone() { Tipo = tipo };
            if (string.IsNullOrEmpty(telefone))
                return tel;
            var charTelefone = telefone.ToCharArray();
            int dd = 0;

            for (int i = 0; i < charTelefone.Count(); i++)
            {
                if (char.IsNumber(charTelefone[i]))
                {
                    if (dd < 2)
                    {
                        tel.Ddd += charTelefone[i];
                    }
                    else
                    {
                        tel.Numero += charTelefone[i];
                    }
                    dd++;
                }
            }
            return tel;
        }

    }

}