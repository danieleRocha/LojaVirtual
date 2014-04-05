using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace LojaVirtual.Infraestrutura.Maps
{
    [Table("Categoria")]
    public class CategoriaMap:IMap
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<MercadoriaMap> Mercadorias { get; set; }
        
        public CategoriaMap()
        {
            Mercadorias = new Collection<MercadoriaMap>();
        }

        public void Atualizar(IContexto contexto)
        {
            var categoriaParaAtualizar = ((Contexto)contexto).Categoria.Find(Id);
            if (categoriaParaAtualizar != null)
            {
                var mercadoriasParaRemover = new List<MercadoriaMap>();

                foreach (var mercadoria in categoriaParaAtualizar.Mercadorias)
                {
                    bool remover = Mercadorias.All(merc => merc.Id != mercadoria.Id);
                    if (remover)
                        mercadoriasParaRemover.Add(mercadoria);
                }

                foreach (var mercadoriaMap in mercadoriasParaRemover)
                {
                    categoriaParaAtualizar.Mercadorias.Remove(mercadoriaMap);
                }

                foreach (var mercadoria in Mercadorias)
                {
                    bool adicionar = categoriaParaAtualizar.Mercadorias.All(merc => merc.Id != mercadoria.Id);
                    if (adicionar)
                    {
                        var merc = ((Contexto)contexto).Mercadoria.Find(mercadoria.Id);
                        if (merc != null)
                        {                           
                            categoriaParaAtualizar.Mercadorias.Add(merc);
                        }
                        else
                        {
                            categoriaParaAtualizar.Mercadorias.Add(mercadoria);
                        }
                        
                    }
                }
            }
        }
        
        public void RemoverDependencias(IContexto contexto)
        {
            if (Mercadorias.Count == 0)
                return;

            IDao<MercadoriaMap> dao = FabricaDeDaos.Instancia().ObterDao<MercadoriaMap>(contexto);
            IList<Guid> listaDeMercadoriasParaRemover = new List<Guid>();
           
            foreach (var mercadoria in Mercadorias)
            {
                bool remover = mercadoria.Categorias.All(categoria => categoria.Id == Id);
                if (remover)
                    listaDeMercadoriasParaRemover.Add(mercadoria.Id);                  
            }

            foreach (var guid in listaDeMercadoriasParaRemover)
            {
                dao.Excluir(guid);
            }
             
        }
    }
}
