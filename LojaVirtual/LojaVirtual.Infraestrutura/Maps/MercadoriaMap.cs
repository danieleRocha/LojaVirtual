using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace LojaVirtual.Infraestrutura.Maps
{
    [Table("Mercadoria")]
    public class MercadoriaMap : IMap
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataDeCadastramento { get; set; }
        public string Cores { get; set; }

        [Required]
        public virtual ICollection<CategoriaMap> Categorias { get; set; }
        public virtual ICollection<FotoMap> Fotos { get; set; }

        [Required]
        public virtual ICollection<ProdutoMap> Produtos { get; set; }

        public MercadoriaMap()
        {
            Fotos = new Collection<FotoMap>();
            Produtos = new Collection<ProdutoMap>();
            Categorias = new Collection<CategoriaMap>();
        }

        public void Atualizar(Contexto contexto)
        {
            var mercadoriaParaAtualizar = contexto.Mercadoria.Find(Id);
            if (mercadoriaParaAtualizar != null)
            {
                var fotosParaRemover = new List<FotoMap>();
                var produtosParaRemover = new List<ProdutoMap>();
                IDao<ProdutoMap> produtoDao = FabricaDeDaos.Instancia().ObterDao<ProdutoMap>(contexto);
                IDao<FotoMap> fotoDao = FabricaDeDaos.Instancia().ObterDao<FotoMap>(contexto);


                foreach (var foto in mercadoriaParaAtualizar.Fotos)
                {
                    bool remover = Fotos.All(f => f.Id != foto.Id);
                    if (remover)
                        fotosParaRemover.Add(foto);
                }

                foreach (var fotoMap in fotosParaRemover)
                {
                    fotoDao.Excluir(fotoMap.Id);
                }
                
                foreach (var produto in mercadoriaParaAtualizar.Produtos)
                {
                    bool remover = Produtos.All(p => p.Id != produto.Id);
                    if (remover)
                        produtosParaRemover.Add(produto);
                }

                foreach (var produtoMap in produtosParaRemover)
                {
                    produtoDao.Excluir(produtoMap.Id);
                }

                foreach (var foto in Fotos)
                {
                    bool adicionar = mercadoriaParaAtualizar.Fotos.All(f => f.Id != foto.Id);
                    if (adicionar)
                    {
                        mercadoriaParaAtualizar.Fotos.Add(foto);
                    }
                }

                foreach (var produto in Produtos)
                {
                    bool adicionar = mercadoriaParaAtualizar.Fotos.All(f => f.Id != produto.Id);
                    if (adicionar)
                    {
                        mercadoriaParaAtualizar.Produtos.Add(produto);
                    }
                }
            }
        }

        public void RemoverDependencias(Contexto contexto)
        {
            //Manter vazio: Dependências são removidas automaticamente.
        }
    }
}
