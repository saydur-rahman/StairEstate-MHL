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
    public class EmployeeTypeService : Service<hr_employee_type>, IEmployeeTypeService
    {
        public EmployeeTypeService(IRepository<hr_employee_type> repository) : base(repository)
        {
        }
    }
}
