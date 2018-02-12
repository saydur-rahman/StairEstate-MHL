using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Repo.Interfaces;

namespace StairEstate.Repo
{
    public class MenuRepository: Repository<sys_menu>, IMenuRepository
    {
        public MenuRepository(MHLDB imhldb) : base(imhldb)
        {
        }
        
        public IEnumerable<sys_menu> GetMenusForCurrentUser(int id)
        {
            var userType = Context.sys_user.SingleOrDefault(u => u.user_id == id);
            int? userTypeId = userType.usr_type_id;

            var menuAccess = Context.sys_user_menu_access.Where(m => m.usr_type_id == userTypeId);

            List<int?> menuAccessId= new List<int?>();

            foreach (var mA in menuAccess)
            {
                menuAccessId.Add(mA.menu_id);
            }



            var menus = Context.sys_menu.Where(m => menuAccessId.Contains(m.menu_id));

            return menus;
        }
    }
}
