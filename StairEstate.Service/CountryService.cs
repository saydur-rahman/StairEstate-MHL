using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Repo.Interfaces;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public class CountryService : Service<sys_country>, ICountryService
    {
        public CountryService(IRepository<sys_country> repository) : base(repository)
        {
        }
    }
}
