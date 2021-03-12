using Shared.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Business
{
    public interface IBDC<T> where T : class
    {
        IRepository<T> Repository { get; set; }
    }
}
