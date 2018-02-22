using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Repo.Interfaces;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public class UserMenuAccessService : Service<sys_user_menu_access>, IUserMenuAccessService
    {
        public UserMenuAccessService(IRepository<sys_user_menu_access> repository) : base(repository)
        {
        }


        public IEnumerable<sys_user_menu_access> GetMenuAccessForUserType(int id)
        {
            var a = _repository.Find(u => u.usr_type_id == id);
            return a;
        }
    }
}
