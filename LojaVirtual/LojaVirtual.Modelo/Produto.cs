using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaVirtual.Modelo
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataDeCadastramento { get; set; }
        public int NumeroDeTamanhos { get; set; }

        private List<string> cores = new List<string>();
        public IEnumerable<string> Cores
        {
            get { return cores; }
            set { cores = value.ToList(); }
        }

        private List<Foto> fotos = new List<Foto>();
        public IEnumerable<Foto> Fotos
        {
            get { return fotos; }
            set { fotos = value.ToList(); }
        }

        private List<Copia> copias = new List<Copia>();
        public IEnumerable<Copia> Copias
        {
            get { return copias; }
            set { copias = value.ToList(); }
        }

        public int NumeroDeCopias
        {
            get { return Copias.Count(); }
        }

        public int NumeroDeCopiasDisponiveis
        {
            get
            {
                return Copias.Count(copia => copia.Estado == Copia.EstadoDaCopiaDoProduto.Disponivel);
            }
        }

        public int NumeroDeCopiasReservadas
        {
            get
            {
                return Copias.Count(copia => copia.Estado == Copia.EstadoDaCopiaDoProduto.Reservada);
            }
        }

        public int NumeroDeCopiasVendidas
        {
            get
            {
                return Copias.Count(copia => copia.Estado == Copia.EstadoDaCopiaDoProduto.Vendida);
            }
        }
        
        public class Copia
        {
            public Guid Id { get; set; }
            public int Sequencial { get; set; }

            private EstadoDaCopiaDoProduto estado = EstadoDaCopiaDoProduto.Disponivel;
            public EstadoDaCopiaDoProduto Estado
            {
                get { return estado; }
            }

            public enum EstadoDaCopiaDoProduto
            {
                Disponivel,
                Reservada,
                Vendida
            }

            public void AlterarEstado(EstadoDaCopiaDoProduto novoEstado)
            {
                estado = novoEstado;
            }
        }

        public void AdicionarCopias(int nCopias)
        {
            for (var i = 0; i < nCopias; i++)
            {
                copias.Add(new Copia(){Id = Guid.NewGuid(),Sequencial = i + 1});
            }
        }
    }
}
