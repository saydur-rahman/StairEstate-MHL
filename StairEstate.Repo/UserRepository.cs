using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Entity.View_Model;
using StairEstate.Repo.Generics;
using StairEstate.Repo.Interfaces;

namespace StairEstate.Repo
{
    public class UserRepository: Repository<sys_user>, IUserRepository
    {
        public UserRepository(MHLDB imhldb) : base(imhldb)
        {
        }

        public sys_user LoginSysUser(sys_user user)
        {
            return Context.sys_user.SingleOrDefault(u =>
                u.user_name == user.user_name && u.user_password == user.user_password);
        }

        public bool CheckAuthorize(string url)
        {
            userVm uv = (userVm) HttpContext.Current.Session["LoggedInUser"];

            var userType = Context.sys_user.SingleOrDefault(u => u.user_id == uv.user_id);
            int? userTypeId = userType.usr_type_id;

            var menuAccess = Context.sys_user_menu_access.Where(m => m.usr_type_id == userTypeId);


            List<int?> menuAccessId = new List<int?>();

            foreach (var mA in menuAccess)
            {
                menuAccessId.Add(mA.menu_id);
            }



            var menus = Context.sys_menu.Where(m => menuAccessId.Contains(m.menu_id));



            foreach (var link in menus)
            {
                if (url.Equals(link.menu_link))
                    return true;
            }

            return false;
        }
    }
}
