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
            get
            {
                if (autenticacao == null)
                    autenticacao = new Autenticacao();
                return autenticacao;
            }
        }

        private static Autorizacao autorizacao;

        public static Autorizacao Autorizacao
        {
            get
            {
                if (autorizacao == null)
                    autorizacao = new Autorizacao();
                return autorizacao;
            }
        }

    }
}
