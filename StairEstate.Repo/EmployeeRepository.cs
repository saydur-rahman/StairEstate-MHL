using System.Collections.Generic;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Repo.Interfaces;
using System.Data.Entity;

namespace StairEstate.Repo
{
    public class EmployeeRepository: Repository<hr_employee>, IEmployeeRepositoy
    {
        public EmployeeRepository(MHLDB imhldb) : base(imhldb)
        {
        }

        public IEnumerable<hr_employee> GetAllWithEmpType()
        {
            return Context.hr_employee.Include(h => h.hr_employee_type);
        }
    }
}
