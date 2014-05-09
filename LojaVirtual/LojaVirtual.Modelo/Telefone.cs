using System;

namespace LojaVirtual.Modelo
{
    public class Telefone
    {
        public Guid Id { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }
        public TipoDeTelefone Tipo { get; set; }

        public enum TipoDeTelefone
        {
            Celular,
            Residencial,
            Comercial
        }

        public bool EIgual(Telefone telefone)
        {
            if ((Ddd == telefone.Ddd) && (Numero == telefone.Numero) && (Tipo == telefone.Tipo))
                return true;

            return false;
        }
    }
}
