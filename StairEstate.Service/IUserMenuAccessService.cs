using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public interface IUserMenuAccessService : IService<sys_user_menu_access>
    {
        IEnumerable<sys_user_menu_access> GetMenuAccessForUserType(int id);
    }

}
