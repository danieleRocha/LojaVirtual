using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infraestrutura.Daos
{
    [Table("Produto")]
    public class ProdutoDao
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Tamanho { get; set; }
    }
}
