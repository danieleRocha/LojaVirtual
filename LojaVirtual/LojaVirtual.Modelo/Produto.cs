using System;

namespace LojaVirtual.Modelo
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Tamanho { get; set; }
        public decimal Preco { get; set; }
        
        private EstadoDoProduto estado = EstadoDoProduto.Disponível;
        public string Estado
        {
            get { return estado.ToString(); }
        }

        public enum EstadoDoProduto
        {
            Disponível,
            AguardandoPagamento,
            Vendido
        }

        public bool Vender()
        {
            if (estado == EstadoDoProduto.Disponível)
            {
                estado = EstadoDoProduto.AguardandoPagamento;
                return true;
            }
            return false;
        }

        public bool ConcluirVenda()
        {
            if (estado == EstadoDoProduto.AguardandoPagamento)
            {
                estado = EstadoDoProduto.Vendido;
                return true;
            }
            return false;
        }

    }
}
