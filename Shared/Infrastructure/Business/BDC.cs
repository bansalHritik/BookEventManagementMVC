using Shared.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Business
{
    public class BDC<T> : BDCBase, IBDC<T> where T : class
    {
        public IRepository<T> Repository { get ; set; }
        public BDC(){}
        public BDC(IRepository<T> repository)
        {
            Repository = repository;
        }
    }
}
