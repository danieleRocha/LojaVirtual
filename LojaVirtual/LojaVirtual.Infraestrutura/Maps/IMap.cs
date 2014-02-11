﻿using System;
using System.Data.Entity.Infrastructure;

namespace LojaVirtual.Infraestrutura.Maps
{
    public interface IMap
    {
        Guid Id { get; set; }
        void Atualizar(Contexto contexto);
        void RemoverDependencias(Contexto contexto);
    }
}
