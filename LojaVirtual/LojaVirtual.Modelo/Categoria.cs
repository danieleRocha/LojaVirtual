using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Modelo
{
    public class Categoria:ITipo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        private List<Mercadoria> mercadorias = new List<Mercadoria>();

        public IEnumerable<Mercadoria> Mercadorias
        {
            get { return mercadorias; }
            set { mercadorias = value.ToList(); }
        }

        public void AdicionarMercadoria(Mercadoria mercadoria)
        {
            if (mercadorias.FirstOrDefault(p => p.Id == mercadoria.Id) == null)
                mercadorias.Add(mercadoria);
        }

        public void RemoverMercadoria(Mercadoria mercadoria)
        {
            if (mercadorias.FirstOrDefault(p => p.Id == mercadoria.Id) != null)
                mercadorias.Remove(mercadoria);
        }

        public void RemoverMercadoria(Guid idMercadoria)
        {
            foreach (var mercadoria in Mercadorias.Where(mercadoria => mercadoria.Id == idMercadoria))
            {
                mercadorias.Remove(mercadoria);
                break;
            }
        }

        public void AdicionarMercadorias(IEnumerable<Mercadoria> mercadoriasAdicionadas)
        {
            foreach (var mercadoria in mercadoriasAdicionadas)
            {
                AdicionarMercadoria(mercadoria);
            }
        }
    }
}
