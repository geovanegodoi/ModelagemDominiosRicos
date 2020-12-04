using System;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoItemRemovidoEvent : Event
    {
        public Guid ClienteId { get; private set; }

        public Guid PedidoId { get; private set; }

        public Guid ProdutoId { get; private set; }

        public PedidoItemRemovidoEvent(Guid clienteId, Guid pedidoId, Guid produtoId)
        {
            ClienteId = clienteId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
        }
    }
}
