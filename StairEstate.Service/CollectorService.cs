using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public class CollectorService : Service<sales_collector>, ICollectorService
    {
        public CollectorService(IRepository<sales_collector> repository) : base(repository)
        {
        }
    }
}
