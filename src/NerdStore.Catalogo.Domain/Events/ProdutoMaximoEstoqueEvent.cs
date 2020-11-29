using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoMaximoEstoqueEvent : DomainEvent
    {
        public int QuantidadeMaxima { get; private set; }

        public ProdutoMaximoEstoqueEvent(Guid aggregateId, int quantidadeMaxima) : base(aggregateId)
        {
            QuantidadeMaxima = quantidadeMaxima;
        }
    }
}
