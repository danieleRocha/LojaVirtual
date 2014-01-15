using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaVirtual.Modelo
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Tamanho { get; set; }
        
        private EstadoDoProduto estado = EstadoDoProduto.Disponível;
        public EstadoDoProduto Estado
        {
            get { return estado; }
        }

        public enum EstadoDoProduto
        {
            Disponível,
            AguardandoPagamento,
            Vendido
        }

        public bool Vender()
        {
            if (Estado == EstadoDoProduto.Disponível)
            {
                estado = EstadoDoProduto.AguardandoPagamento;
                return true;
            }
            return false;
        }

        public bool ConcluirVenda()
        {
            if (Estado == EstadoDoProduto.AguardandoPagamento)
            {
                estado = EstadoDoProduto.Vendido;
                return true;
            }
            return false;
        }



    }
}
