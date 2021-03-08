using DAL.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationContext context) : base(context) {}

        public ApplicationContext ApplicationContext
        {
            get{ return Context as ApplicationContext; }
        }
    }
}
