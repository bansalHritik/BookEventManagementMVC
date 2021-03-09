using DAL.Repository;
using Entities.Models;

namespace Entities.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationContext context) : base(context) { }

        public ApplicationContext ApplicationContext
        {
            get { return Context as ApplicationContext; }
        }
    }
}
