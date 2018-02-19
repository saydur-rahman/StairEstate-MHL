using StairEstate.Entity;
using StairEstate.Service.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairEstate.Service
{
    public interface IEmployeeService : IService<hr_employee>
    {
        IEnumerable<hr_employee> GetAllWithEmpType();
    }
}
