using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Modelo
{
    public class Usuario:ITipo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public Sexos Sexo { get; set; }
        public Endereco Endereco { get; set; }

        private List<Telefone> telefones = new List<Telefone>();

        public IEnumerable<Telefone> Telefones
        {
            get { return telefones; }
            set { telefones = value.ToList(); }
        }

        public enum Sexos
        {
            Femenino,
            Masculino
        }
        
    }
}
