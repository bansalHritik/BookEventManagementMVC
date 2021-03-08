using Entities.Repository;
using System;

namespace Entities.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        int Complete();
    }
}
