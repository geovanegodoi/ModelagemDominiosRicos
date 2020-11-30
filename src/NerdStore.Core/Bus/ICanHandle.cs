using System;
using MediatR;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Bus
{
    public interface ICanHandleEvent<T> : INotificationHandler<T> where T : Event { }

    public interface ICanHandleCommand<T> : IRequestHandler<T, bool> where T : Command { }
}
