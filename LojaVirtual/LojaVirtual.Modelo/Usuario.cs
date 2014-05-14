using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Modelo
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public Sexos Sexo { get; set; }
        public Endereco Endereco { get; set; }
        public Carrinho Carrinho { get; set; }

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

        public void EditarTelefones(IEnumerable<Telefone> telefones)
        {
            var telefonesParaEditar = new List<Telefone>(Telefones);

            foreach (var telefone in telefonesParaEditar)
            {
                bool achou = telefones != null && telefones.Any(novoTelefone => telefone.EIgual(novoTelefone));

                if (!achou)
                    this.telefones.Remove(telefone);
            }

            if (telefones == null) return;
            
            foreach (var telefone in telefones)
            {
                bool achou = this.telefones.Any(telefoneAntigo => telefone.EIgual(telefoneAntigo));

                if (!achou)
                    this.telefones.Add(telefone);
            }
        }

        public void EditarEndereco(Endereco endereco)
        {
            if (!Endereco.EIgual(endereco))
            {
                Endereco = endereco;
            }
        }
    }
}
