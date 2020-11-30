using System;
using System.Threading.Tasks;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Data
{
    public interface IRepository<T> : IDisposable
        where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
