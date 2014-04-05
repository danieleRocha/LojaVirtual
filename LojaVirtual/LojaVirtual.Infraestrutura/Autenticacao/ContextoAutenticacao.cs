using System.Data.Entity;
using LojaVirtual.Infraestrutura.Maps;

namespace LojaVirtual.Infraestrutura.Autenticacao
{
    public class ContextoAutenticacao : ContextoBase
    {
        public DbSet<TelefoneMap> Telefone { get; set; }
        public DbSet<EnderecoMap> Endereco { get; set; }
        public DbSet<UsuarioMap> Usuario { get; set; }
        public DbSet<PermissaoMap> Permissao { get; set; }
        
    }
}