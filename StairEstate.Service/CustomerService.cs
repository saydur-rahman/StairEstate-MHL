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
    public class CustomerService : Service<sales_customer>, ICustomerService
    {
        public CustomerService(IRepository<sales_customer> repository) : base(repository)
        {
        }
    }
}
