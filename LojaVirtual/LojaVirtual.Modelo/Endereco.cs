using System;

namespace LojaVirtual.Modelo
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public Estados Estado { get; set; }
        public string Cep { get; set; }
        
        public enum Estados
        {
            AC,
            AL,
            AP,
            AM,
            BA,
            CE,
            DF,
            ES,
            GO,
            MA,
            MT,
            MS,
            MG,
            PA,
            PB,
            PE,
            PI,
            PR,
            RJ,
            RN,
            RO,
            RR,
            RS,
            SC,
            SE,
            SP,
            TO
        }

    }

    
}
