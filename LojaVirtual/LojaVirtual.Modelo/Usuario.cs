using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Modelo
{
    public abstract class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public Sexos Sexo { get; set; }
        public Permissao Permissao { get; set; }

        private List<Endereco> enderecos = new List<Endereco>();

        public IEnumerable<Endereco> Enderecos
        {
            get { return enderecos; }
        }

        private List<Telefone> telefones = new List<Telefone>();

        public IEnumerable<Telefone> Telefones
        {
            get { return telefones; }
        }

        public enum Sexos
        {
            Masculino,
            Femenino
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            if (enderecos.FirstOrDefault(p => p.Id == endereco.Id) == null)
                enderecos.Add(endereco);
        }

        public void RemoverEndereco(Endereco endereco)
        {
            if (enderecos.FirstOrDefault(p => p.Id == endereco.Id) == null)
                enderecos.Remove(endereco);
        }

        public void AdicionarTelefone(Telefone telefone)
        {
            if (telefones.FirstOrDefault(p => p.Id == telefone.Id) == null)
                telefones.Add(telefone);
        }

        public void RemoverTelefone(Telefone telefone)
        {
            if (telefones.FirstOrDefault(p => p.Id == telefone.Id) == null)
                telefones.Remove(telefone);
        }

    }
}
