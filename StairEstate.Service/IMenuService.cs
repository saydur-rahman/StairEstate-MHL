using System.Collections.Generic;
using StairEstate.Entity;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public interface IMenuService : IService<sys_menu>
    {
        IEnumerable<sys_menu> GetSysMenus();
    }
}