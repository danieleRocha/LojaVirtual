using System.Data.Entity;
using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura
{
    public class Contexto : ContextoBase
    {
        //public Contexto()
        //    : base("Name=BaseDeDadosLojaVirtual")
        //{
            
        //}

        public DbSet<ProdutoMap> Produto { get; set; }
        public DbSet<MercadoriaMap> Mercadoria { get; set; }
        public DbSet<CategoriaMap> Categoria { get; set; }
        public DbSet<FotoMap> Foto { get; set; }
        public DbSet<CompraMap> Compra { get; set; }

    }
}