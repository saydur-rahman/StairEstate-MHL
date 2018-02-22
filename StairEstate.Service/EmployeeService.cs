using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Service.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Repo.Interfaces;

namespace StairEstate.Service
{
    public class EmployeeService : Service<hr_employee>, IEmployeeService
    {
        private readonly IEmployeeRepositoy _repository;

        public EmployeeService(IEmployeeRepositoy repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<hr_employee> GetAllWithEmpType()
        {
            return _repository.GetAllWithEmpType();
        }
    }
}
