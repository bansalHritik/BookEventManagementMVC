using Entities.Core;
using Entities.Repository;
using System;

namespace Entities.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public IEventRepository Events { get; private set; }

        public UnitOfWork()
        {
            _context = new ApplicationContext();
            Events = new EventRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
