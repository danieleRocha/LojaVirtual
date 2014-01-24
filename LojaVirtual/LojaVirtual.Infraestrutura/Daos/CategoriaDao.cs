using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infraestrutura.Daos
{
    [Table("Categoria")]
    public class CategoriaDao
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
