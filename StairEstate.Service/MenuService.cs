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
    public class MenuService : Service<sys_menu>, IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public IEnumerable<sys_menu> GetSysMenus()
        {
            if (UserSession.GetUserFromSession() != null)
                return _menuRepository.GetMenusForCurrentUser(UserSession.GetUserFromSession().user_id);

            return null;
        }
    }
}
