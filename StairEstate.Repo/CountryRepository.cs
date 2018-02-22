using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Repo.Interfaces;

namespace StairEstate.Repo
{
    public class CountryRepository: Repository<sys_country>, ICountryRepository
    {
        public CountryRepository(MHLDB imhldb) : base(imhldb)
        {
        }
    }
}
