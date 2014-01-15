using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Modelo;

namespace LojaVirtual.Repositorio
{
    public class Repositorio<T>:IRepositorio<T> where T:ITipo 
    {

#region CategoriasMock
        private List<ITipo> CategoriasMock = new List<ITipo>()
            {
                new Categoria()
                    {
                        Id = Guid.NewGuid(),
                        Descricao = "Descrição da Categoria 1",
                        Mercadorias = new List<Mercadoria>(),
                        Nome = "Categoria 1"
                    },
                    new Categoria()
                    {
                        Id = Guid.NewGuid(),
                        Descricao = "Descrição da Categoria 2",
                        Mercadorias = new List<Mercadoria>(),
                        Nome = "Categoria 2"
                    },
                    new Categoria()
                    {
                        Id = Guid.NewGuid(),
                        Descricao = "Descrição da Categoria 3",
                        Mercadorias = new List<Mercadoria>(),
                        Nome = "Categoria 3"
                    }
            };
#endregion CategoriasMock

#region MercadoriasMock

        private List<ITipo> MercadoriasMock = new List<ITipo>()
            {
                new Mercadoria()
                    {
                        Id = Guid.NewGuid(),
                        Descricao = "Descrição da Mercadoria 1",
                        Cores = new List<string>(){Catalogo.Cores[0],Catalogo.Cores[3]},
                        DataDeCadastramento = DateTime.Now,
                        Fotos = new List<Foto>(),
                        Preco = 100.51m,
                        Produtos = new List<Produto>(),
                        Nome = "Mercadoria 1"
                    },
                    new Mercadoria()
                    {
                        Id = Guid.NewGuid(),
                        Descricao = "Descrição da Mercadoria 2",
                        Cores = new List<string>(){Catalogo.Cores[5],Catalogo.Cores[6]},
                        DataDeCadastramento = DateTime.Now,
                        Fotos = new List<Foto>(),
                        Preco = 54.30m,
                        Produtos = new List<Produto>(),
                        Nome = "Mercadoria 2"
                    },
                    new Mercadoria()
                    {
                       Id = Guid.NewGuid(),
                        Descricao = "Descrição da Mercadoria 3",
                        Cores = new List<string>(){Catalogo.Cores[2],Catalogo.Cores[8]},
                        DataDeCadastramento = DateTime.Now,
                        Fotos = new List<Foto>(),
                        Preco = 64.99m,
                        Produtos = new List<Produto>(),
                        Nome = "Mercadoria 3"
                    }
            };

        #endregion MercadoriasMock

        public Repositorio()
        {
            
        }

        public List<ITipo> ObterTodos()
        {
            if (typeof (T) == typeof (Categoria))
                return CategoriasMock;
            if (typeof(T) == typeof(Mercadoria))
                return MercadoriasMock;

            return null;
        }
    }
}
