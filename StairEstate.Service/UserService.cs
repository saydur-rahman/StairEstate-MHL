using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Repo;
using StairEstate.Repo.Interfaces;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public class UserService :Service<sys_user>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public sys_user ValidateUser(sys_user user)
        {
            return _repository.LoginSysUser(user);
        }

        public bool AuthorizedUser(string url)
        {
            return _repository.CheckAuthorize(url);
        }
    }


}
