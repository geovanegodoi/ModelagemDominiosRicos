using System;
using System.Threading;
using System.Threading.Tasks;
using NerdStore.Core.Communication.Mediator;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoEventHandler :
        ICanHandleEvent<PedidoRascunhoIniciadoEvent>,
        ICanHandleEvent<PedidoAtualizadoEvent>,
        ICanHandleEvent<PedidoItemAdicionadoEvent>
    {
        public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
