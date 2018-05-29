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
    public class BranchService : Service<sys_branch>, IBranchService
    {
        public BranchService(IRepository<sys_branch> repository) : base(repository)
        {
        }
    }
}
