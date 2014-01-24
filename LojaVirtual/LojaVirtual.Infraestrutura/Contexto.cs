using System.Data.Entity;
using LojaVirtual.Infraestrutura.Daos;

namespace LojaVirtual.Infraestrutura
{
    public class Contexto : DbContext,IUnitOfWork
    {
        public DbSet<ProdutoDao> Produto { get; set; }
        
        
        public void Save()
        {
            base.SaveChanges();
        }
    }
}