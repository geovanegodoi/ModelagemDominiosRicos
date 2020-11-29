using MediatR;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Bus
{
    public interface ICanHandle<T> : INotificationHandler<T> where T : Event { }
}
