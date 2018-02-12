using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Repo.Generics;

namespace StairEstate.Repo.Interfaces
{
    public interface IUserRepository: IRepository<sys_user>
    {
        sys_user LoginSysUser(sys_user user);

        bool CheckAuthorize(string url);
    }
}
