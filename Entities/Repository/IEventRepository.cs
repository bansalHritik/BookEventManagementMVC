using DAL.Repository;
using Entities.Models;
using Shared.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repository
{
    public interface IEventRepository : IRepository<Event>
    {

    }
}
