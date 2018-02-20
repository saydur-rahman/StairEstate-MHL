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
    public class ProfessionService : Service<hr_profession>, IProfessionService
    {
        public ProfessionService(IRepository<hr_profession> repository) : base(repository)
        {
        }
    }
}
