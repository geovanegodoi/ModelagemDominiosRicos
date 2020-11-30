using System;
using System.Collections.Generic;
using MediatR;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Core.Communication.Mediator
{
    public interface ICanHandleEvent<T> : INotificationHandler<T>
        where T : Event { }

    public interface ICanHandleCommand<T> : IRequestHandler<T, bool>
        where T : Command { }

    public interface ICanHandleNotification<T> : INotificationHandler<T>
        where T : DomainNotification
    {
        List<DomainNotification> ObterNotificacoes();

        bool TemNotificacoes();
    }
}
