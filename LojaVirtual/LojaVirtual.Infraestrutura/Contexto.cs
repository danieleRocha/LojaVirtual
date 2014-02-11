using System.Data.Entity;
using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura
{
    public class Contexto : DbContext,IUnitOfWork
    {
        //public Contexto()
        //    : base("Name=BaseDeDadosLojaVirtual")
        //{
            
        //}

        public DbSet<ProdutoMap> Produto { get; set; }
        public DbSet<MercadoriaMap> Mercadoria { get; set; }
        public DbSet<CategoriaMap> Categoria { get; set; }
        public DbSet<FotoMap> Foto { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<MercadoriaMap>().HasRequired(c=>c.Categorias).WillCascadeOnDelete();

        //    base.OnModelCreating(modelBuilder);
        //}
        
        public void Save()
        {
            base.SaveChanges();
        }
       
    }
}