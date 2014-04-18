using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;

namespace LojaVirtual.Servico
{
    public class Seguranca : ISeguranca
    {
        private static Autenticacao autenticacao;
        public static Autenticacao Autenticacao
        {
            get { return autenticacao; }
        }
        private static Autorizacao autorizacao;
        public static Autorizacao Autorizacao
        {
            get { return autorizacao; }
        }

        public Seguranca()
        {
           CriarAutenticacaoEAutorizacao();
        }
        
        public void CriarAutenticacaoEAutorizacao()
        {
            autenticacao = new Autenticacao();
            autorizacao = new Autorizacao();
        }
    }
}
