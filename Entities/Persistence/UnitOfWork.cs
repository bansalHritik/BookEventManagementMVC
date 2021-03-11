using Entities.Core;
using Entities.Models;
using Entities.Repository;
using System;

namespace Entities.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public IEventRepository Events { get; private set; }
        public ICommentRepository Comments { get; set; }
        public IInvitationRepository Invitations { get; set; }

        public UnitOfWork()
        {
            _context = new ApplicationContext();

            Events = new EventRepository(_context);
            Comments = new CommentRepository(_context);
            Invitations = new InvitationRepository(_context);
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
