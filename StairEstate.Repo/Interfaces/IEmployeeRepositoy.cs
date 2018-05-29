using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Repo.Generics;

namespace StairEstate.Repo.Interfaces
{
    public interface IEmployeeRepositoy: IRepository<hr_employee>
    {
        IEnumerable<hr_employee> GetAllWithEmpType();
    }
}
