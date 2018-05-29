using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Repo.Generics;

namespace StairEstate.Repo.Interfaces
{
    public interface IUserMenuPermissionRepository : IRepository<sys_user_menu_access>
    {
       
    }
}
